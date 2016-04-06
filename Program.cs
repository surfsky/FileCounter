using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace LineCounter
{
    class Program
    {
        // 配置信息
        static string _root;             // 根目录
        static string _outFile;          // 输出的合并文件名称
        static long _maxLines = 2000;    // 最大合并输出行数
        static Encoding _encoding = Encoding.GetEncoding(ConfigurationManager.AppSettings["Encoding"]);                     // 字符集
        static int _maxContinuousBlankLines = int.Parse(ConfigurationManager.AppSettings["MaxContinuousBlankLines"]);       // 允许连续空行数
        static int _maxContinuousCommentLines = int.Parse(ConfigurationManager.AppSettings["MaxContinuousCommentLines"]);   // 允许连续注释行数
        static string[] _exts = ConfigurationManager.AppSettings["extensions"]
            .Replace(" ", "")
            .Replace("\r", "")
            .Replace("\n", "")
            .Replace("\t", "")
            .Split('|', ',', ';');

        // 运行时信息
        static Dictionary<string, Counter> _counter = new Dictionary<string, Counter>();   // 统计器
        static long _totalLines = 0;     // 代码行数
        static StreamWriter _sw;         // 文件输出器


        // 入口
        static void Main(string[] args)
        {
            Log("-----------------------------------------");
            Log("LineCounter");
            Log("surfsky.cnblogs.com");
            Log("LastUpdated: 2016-04-15");
            Log("-----------------------------------------");

            // prepare
            if (args.Length == 0)
            {
                Log("请输入");
                Log("参数1：待统计目录的路径");
                Log("参数2[可选]：合并输出文件名路径");
                Log("参数3[可选]：合并输出文件最大行数（默认2000行)");
                Log("");
                Log("按任意键退出");
                Console.ReadKey();
                return;
            }
            _root = args[0];
            if (args.Length >= 2) _outFile = args[1];
            if (args.Length >= 2) _maxLines = Convert.ToInt32(args[2]);

            // start
            _totalLines = 0;
            _sw = (_outFile == null) ? null : new StreamWriter(_outFile);
            Log("{0}", System.DateTime.Now);
            ProcessFolder(_root);
            if (_sw != null)
                _sw.Close();

            // end
            int files, lines;
            GetTotalFiles(out files, out lines);
            Log("");
            Log("-----------------------------------------");
            Log("-- " + _root);
            Log("-- {0}", System.DateTime.Now);
            Log("-----------------------------------------");
            Log("类别\t文件数\t代码行数\t平均");
            Log("----\t------\t--------\t--------");
            foreach (string key in _counter.Keys)
            {
                Counter cnt = _counter[key];
                Log("{0}\t{1}\t{2}\t{3}", key, cnt.Files, cnt.Lines, GetAverage(cnt.Lines, cnt.Files));
            }
            Log("----\t------\t--------");
            Log("    \t{0}\t{1}\t{2}", files, lines, GetAverage(lines, files));
            Log("");
            //Log("{0}", _root);
            //Console.ReadKey();
        }

        // 统计平均每文件代码行数
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
                Counter cnt = _counter[key];
                files += cnt.Files;
                lines += cnt.Lines;
            }
        }

        // 处理一个目录
        static void ProcessFolder(string folder)
        {
            if (!System.IO.Directory.Exists(folder))
                return;
            DirectoryInfo di = new DirectoryInfo(folder);

            // 递归子目录
            foreach (DirectoryInfo info in di.GetDirectories())
                ProcessFolder(info.FullName);

            // 处理目录内的文件
            Log("-----------------------------------------");
            Log("目录 {0}", di.FullName);
            foreach (FileInfo fi in di.GetFiles())
            {
                // 扩展名(去掉前面的点)
                string ext = fi.Extension.ToLower();
                if (ext.Length > 0) 
                    ext = ext.Remove(0, 1);

                // 过滤不在清单中的文件
                if (ext == "" || !_exts.Contains(ext))
                {
                    Log("跳过 {0}", fi.FullName);
                    continue;
                }

                // 处理文件
                FileCounter fc = ProcessFile(fi.FullName);
                
                // 根据扩展名进行统计
                if (!_counter.Keys.Contains(ext))
                    _counter.Add(ext, new Counter());
                _counter[ext].Files += 1;
                _counter[ext].Lines += fc.Lines;
                Log("行数 {0}  {1}", fc.Lines, fi.FullName);
            }
            Log("-----------------------------------------");
        }

        // 处理单个文本文件，返回文件代码行数（以后可考虑优化，返回一个结构体）
        static FileCounter ProcessFile(string filePath)
        {
            FileCounter fc = new FileCounter(filePath, _encoding);
            string relativePath = filePath.Substring(_root.Length);
            WriteLineToFile(@"【文件】 " + relativePath, false);

            // 遍历代码行
            using (StreamReader sr = new StreamReader(filePath, fc.Encoding))
            {
                int blankLines = 0;
                int commentLines = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    
                    // 跳过连续注释行
                    if (!IsCommentLine(line))
                        commentLines = 0;
                    else
                    {
                        commentLines++;
                        fc.CommentLines++;
                        if (commentLines >= _maxContinuousCommentLines)
                            continue;
                    }

                    // 跳过连续空行
                    if (line != "")
                        blankLines = 0;
                    else
                    {
                        blankLines++;
                        fc.BlankLines++;
                        if (blankLines >= _maxContinuousBlankLines)
                            continue;
                    }

                    // 输出到文件
                    WriteLineToFile(line, true);
                    fc.Lines++;
                }
            }

            //
            WriteLineToFile("", false);
            WriteLineToFile("", false);
            _totalLines += fc.Lines;
            return fc;
        }

        
        // 是否是注释行
        static bool IsCommentLine(string line)
        {
            line = line.TrimStart();
            if (line.Length < 2)
                return false;
            else
                return line.Substring(0, 2) == "//";
        }

        // 输出代码行（到文件）
        private static void WriteLineToFile(string line, bool countLine=true)
        {
            if (_sw != null && _totalLines < _maxLines)
                _sw.WriteLine(line);
            if (countLine)
                _totalLines++;
        }


        // 日志（到控制台）
        static void Log(string format, params object[] parameters)
        {
            Console.WriteLine(format, parameters);
        }
    }
}
