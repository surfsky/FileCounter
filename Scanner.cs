using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileCounter
{
    /// <summary>统计数据</summary>
    public class Stat
    {
        public int Files;  // 文件数
        public int Lines;  // 代码行数
    }


    /// <summary>
    /// 扫描统计器
    /// </summary>
    public static class Scanner
    {
        // 计数字典（文件类型-文件数-代码行数）
        static Dictionary<string, Stat> _counter = new Dictionary<string, Stat>();

        // console
        public static void Run(Config cfg)
        {
            // 参数校验
            var root = cfg.RootFolder;
            var outFile = cfg.OutFile;
            if (root.IsEmpty())
            {
                MessageBox.Show("请录入源代码目录", "错误");
                return;
            }

            // 处理
            long totleLines = 0;
            StreamWriter sw = (outFile == null) ? null : new StreamWriter(outFile);
            Logger.Log(ConfigurationManager.AppSettings["about"]);
            Logger.Log("{0}", System.DateTime.Now);
            ProcessFolder(cfg, root, ref totleLines, ref sw);
            if (sw != null)
                sw.Close();

            // 显示统计信息
            int files, lines;
            GetTotalFiles(out files, out lines);
            Logger.Log("");
            Logger.Log("-----------------------------------------");
            Logger.Log("-- " + root);
            Logger.Log("-----------------------------------------");
            Logger.Log("类别\t文件数\t代码行数\t平均");
            Logger.Log("----\t------\t--------\t--------");
            foreach (string key in _counter.Keys)
            {
                Stat cnt = _counter[key];
                Logger.Log("{0}\t{1}\t{2}\t{3}", key, cnt.Files, cnt.Lines, GetAverage(cnt.Lines, cnt.Files));
            }

            Logger.Log("----\t------\t--------");
            Logger.Log("合计\t{0}\t{1}\t{2}", files, lines, GetAverage(lines, files));
            Logger.Log("");
            Logger.Log("{0}", System.DateTime.Now);
            Logger.Log("{0}", root);

            // 打开输出文件
            if (cfg.OpenWhenFinished && !cfg.OutFile.IsEmpty())
                System.Diagnostics.Process.Start(cfg.OutFile);
        }

        static double GetAverage(int lines, int files)
        {
            if (files == 0) return 0;
            //else return lines*1.0 / files;
            else return Math.Round((double)(lines * 1.0 / files));
        }

        // 统计
        static void GetTotalFiles(out int files, out int lines)
        {
            files = 0;
            lines = 0;
            foreach (string key in _counter.Keys)
            {
                Stat cnt = _counter[key];
                files += cnt.Files;
                lines += cnt.Lines;
            }
        }


        // 处理单个文本文件
        static int ProcessFile(Config cfg, string filePath, ref long totleLines, ref StreamWriter sw)
        {
            int lines = 0;
            int blankLines = 0;
            int commentLines = 0;
            var relativePath = GetRelativePath(cfg.RootFolder, filePath);
            WriteLineToFile(cfg, sw, @"//////////////////////////////////////////////////////", totleLines);
            WriteLineToFile(cfg, sw, @"// " + relativePath, totleLines);
            WriteLineToFile(cfg, sw, @"//////////////////////////////////////////////////////", totleLines);
            using (StreamReader sr = new StreamReader(filePath, cfg.Enc))
            {
                while (!sr.EndOfStream)
                {
                    lines++;
                    string line = sr.ReadLine();

                    // 跳过连续空行；跳过连续备注行
                    blankLines = !line.IsEmpty() ? 0 : blankLines + 1;
                    commentLines = !line.IsCommentLine() ? 0 : commentLines + 1;
                    if (cfg.SkipBlankLines && blankLines > 1) continue;
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

        /// <summary>获取相对路径</summary>
        /// <param name="rootFolder">根目录</param>
        /// <param name="filePath">文件完整目录</param>
        private static string GetRelativePath(string rootFolder, string filePath)
        {
            return filePath.Substring(rootFolder.Length);
        }

        // 处理一个目录
        static void ProcessFolder(Config cfg, string folder, ref long totleLines, ref StreamWriter sw)
        {
            // 目录校验
            if (!Directory.Exists(folder))
                return;

            // 跳过目录
            DirectoryInfo di = new DirectoryInfo(folder);
            //var relativeFolder = folder.Substring(cfg.RootFolder.Length).ToLower().TrimStart('\\', '/');
            if (cfg.SkipSubFolders.Contains(di.Name.ToLower()))
            {
                Logger.Log("跳过忽略目录 {0}", folder);
                return;
            }
            if (cfg.SkipHidden && di.Attributes.HasFlag(FileAttributes.Hidden))
            {
                Logger.Log("跳过隐藏目录 {0}", folder);
                return;
            }


            // 处理当前目录文件
            Logger.Log("-----------------------------------------");
            Logger.Log("处理目录 {0}", di.FullName);
            var files = di.GetFiles().OrderBy(t => t.Name).ToList();
            foreach (FileInfo fi in files)
            {
                // 扩展名(去掉前面的点)
                string ext = fi.Extension.ToLower();
                if (ext.Length > 0)
                    ext = ext.Remove(0, 1);
                if (ext == "" || !cfg.Extensions.Contains(ext))
                {
                    Logger.Log("跳过 {0}", fi.FullName);
                    continue;
                }

                // 文件行数
                int line = ProcessFile(cfg, fi.FullName, ref totleLines, ref sw);

                // 统计文件数和行数
                if (!_counter.Keys.Contains(ext))
                    _counter.Add(ext, new Stat());
                _counter[ext].Files += 1;
                _counter[ext].Lines += line;
                Logger.Log("行数 {0}  {1}", line, fi.FullName);
            }

            // 递归子目录
            var dirs = di.GetDirectories().OrderBy(t => t.FullName).ToList();
            foreach (DirectoryInfo info in dirs)
                ProcessFolder(cfg, info.FullName, ref totleLines, ref sw);
        }

        /// <summary>输出一行文本（如果未超出总行数限制）</summary>
        private static void WriteLineToFile(Config cfg, StreamWriter sw, string line, long totleCnt)
        {
            if (sw != null && totleCnt < cfg.OutLines)
                sw.WriteLine(line);
        }
    }
}