using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LineCounter
{
    /// <summary>
    /// 计数器
    /// </summary>
    public class Counter
    {
        public int Files;
        public int Lines;
    }

    /// <summary>
    /// 文件统计器
    /// </summary>
    public class FileCounter
    {
        public string FilePath;
        public string Extension;
        public long Length;
        public int Lines;
        public int BlankLines;
        public int CommentLines;
        public System.Text.Encoding Encoding = Encoding.UTF8;

        public FileCounter(string filePath, Encoding encoding=null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            this.FilePath = filePath;
            FileInfo fi = new FileInfo(filePath);
            this.Extension = fi.Extension;
            this.Length = fi.Length;
        }
    }

    /// <summary>
    /// 目录统计器
    /// </summary>
    public class FolderCounter
    {
        public string Folder;
        public List<FolderCounter> SubFolders;
        public List<FileCounter> Files;

        public FolderCounter(string folder)
        {
            this.Folder = folder;
        }
    }
}
