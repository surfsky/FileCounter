using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Windows.Forms;

namespace FileMerger
{
    /// <summary>计数器</summary>
    public class FileCounter
    {
        public int Files;
        public int Lines;
    }


    class Program
    {
        // 计数字典（文件类型-文件数-代码行数）
        static Dictionary<string, FileCounter> _counter = new Dictionary<string, FileCounter>();


        // entry
        [STAThread]
        static void Main(string[] args)
        {
            Log("-----------------------------------------");
            Log("FileMerger");
            Log("Version {0}", Helper.GetVersion());
            Log("https://www.github.com/surfsky/");
            Log("2019-06");
            Log("-----------------------------------------");


            if (args.Length == 0)
                Application.Run(new FormMain());
            else
            {
                var cfg = new Config();
                cfg.Folder = args[0];
                cfg.OutFile = args[1];
                cfg.OutLines = Convert.ToInt32(args[2]);
                cfg.Extensions = ConfigurationManager.AppSettings["Extensions"].ToArray();
                cfg.SkipBlankLines = ConfigurationManager.AppSettings["SkipBlankLines"].ToBool();
                cfg.SkipCommentLines = ConfigurationManager.AppSettings["SkipCommentLines"].ToBool();
                cfg.OpenWhenFinished = ConfigurationManager.AppSettings["OpenWhenFinished"].ToBool();
                cfg.Encoding = ConfigurationManager.AppSettings["Encoding"];
                RunConsole(cfg);
            }
        }


        // console
        public static void RunConsole(Config cfg)
        {
            // 参数校验
            var folder = cfg.Folder;
            var outFile = cfg.OutFile;
            var outLines = cfg.OutLines;
            if (folder.IsEmpty())
            {
                MessageBox.Show("请录入源代码目录", "错误");
                return;
            }

            // 处理
            long totleLines = 0;
            StreamWriter sw = (outFile == null) ? null : new StreamWriter(outFile);
            Log(ConfigurationManager.AppSettings["about"]);
            Log("{0}", System.DateTime.Now);
            ProcessFolder(cfg, folder, ref totleLines, ref sw);
            if (sw != null)
                sw.Close();

            // 显示统计信息
            int files, lines;
            GetTotalFiles(out files, out lines);
            Log("");
            Log("-----------------------------------------");
            Log("-- " + folder);
            Log("-----------------------------------------");
            Log("类别\t文件数\t代码行数\t平均");
            Log("----\t------\t--------\t--------");
            foreach (string key in _counter.Keys)
            {
                FileCounter cnt = _counter[key];
                Log("{0}\t{1}\t{2}\t{3}", key, cnt.Files, cnt.Lines, GetAverage(cnt.Lines, cnt.Files));
            }
            Log("----\t------\t--------");
            Log("合计\t{0}\t{1}\t{2}", files, lines, GetAverage(lines, files));
            Log("");
            Log("{0}", System.DateTime.Now);
            Log("{0}", folder);

            // 打开输出文件
            if (cfg.OpenWhenFinished && !cfg.OutFile.IsEmpty())
                System.Diagnostics.Process.Start(cfg.OutFile);
        }

        static double GetAverage(int lines, int files)
        {
            if (files == 0) return 0;
            //else return lines*1.0 / files;
            else return Math.Round((double)(lines*1.0 / files));
        }

        // 统计
        static void GetTotalFiles(out int files, out int lines)
        {
            files = 0;
            lines = 0;
            foreach (string key in _counter.Keys)
            {
                FileCounter cnt = _counter[key];
                files += cnt.Files;
                lines += cnt.Lines;
            }
        }

        // 处理一个目录
        static void ProcessFolder(Config cfg, string folder, ref long totleLines, ref StreamWriter sw)
        {
            if (!System.IO.Directory.Exists(folder))
                return;
            DirectoryInfo di = new DirectoryInfo(folder);

            // 递归子目录
            foreach (DirectoryInfo info in di.GetDirectories())
                ProcessFolder(cfg, info.FullName, ref totleLines, ref sw);

            // 处理目录内的文件
            Log("-----------------------------------------");
            Log("目录 {0}", di.FullName);
            foreach (FileInfo fi in di.GetFiles())
            {
                // 扩展名(去掉前面的点)
                string ext = fi.Extension.ToLower();
                if (ext.Length > 0) 
                    ext = ext.Remove(0, 1);

                if (ext == "" || !cfg.Extensions.Contains(ext))
                {
                    Log("跳过 {0}", fi.FullName);
                    continue;
                }

                // 文件行数
                int line = ProcessFile(cfg, fi.FullName, ref totleLines, ref sw);
                
                // 统计文件数和行数
                if (!_counter.Keys.Contains(ext))
                    _counter.Add(ext, new FileCounter());
                _counter[ext].Files += 1;
                _counter[ext].Lines += line;
                Log("行数 {0}  {1}", line, fi.FullName);
            }
            Log("-----------------------------------------");
        }

        // 处理单个文本文件
        static int ProcessFile(Config cfg, string filePath, ref long totleLines, ref StreamWriter sw)
        {
            int lines = 0;
            int blankLines = 0;
            int commentLines = 0;
            WriteLineToFile(cfg, sw, @"§ " + filePath, totleLines);
            using (StreamReader sr = new StreamReader(filePath, cfg.Enc))
            {
                while (!sr.EndOfStream)
                {
                    lines++;
                    string line = sr.ReadLine();

                    // 跳过连续空行；跳过连续备注行
                    blankLines = !line.IsEmpty() ? 0 : blankLines + 1;
                    commentLines = !line.IsCommentLine() ? 0 : commentLines + 1;
                    if (cfg.SkipBlankLines && blankLines > 1)     continue;
                    if (cfg.SkipCommentLines && commentLines > 1) continue;

                    //
                    WriteLineToFile(cfg, sw, line, totleLines);
                }
            }
            WriteLineToFile(cfg, sw, "", totleLines);
            WriteLineToFile(cfg, sw, "", totleLines);
            totleLines += lines;
            return lines;
        }

        /// <summary>输出一行文本（如果未超出总行数限制）</summary>
        private static void WriteLineToFile(Config cfg, StreamWriter sw, string line, long totleCnt)
        {
            if (sw != null && totleCnt < cfg.OutLines)
                sw.WriteLine(line);
        }

        // 写日志
        static void Log(string format, params object[] parameters)
        {
            Console.WriteLine(format, parameters);
        }
    }
}
