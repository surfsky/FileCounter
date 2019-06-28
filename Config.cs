using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileMerger
{
    /// <summary>
    /// 运行参数
    /// </summary>
    public class Config
    {
        // 源控制
        public string Folder { get; set; }
        public string[] Extensions { get; set; }
        public string Encoding { get; set; }

        // 辅助参数
        public bool SkipBlankLines { get; set; }
        public bool SkipCommentLines { get; set; }
        public bool OpenWhenFinished { get; set; }

        // 输出控制
        public string OutFile { get; set; }
        public int OutLines { get; set; } = 9000;

        public Encoding Enc
        {
            get
            {
                try
                {
                    return System.Text.Encoding.GetEncoding(this.Encoding);
                }
                catch (Exception ex)
                {
                    return System.Text.Encoding.UTF8;
                }
            }
        }
    }
}
