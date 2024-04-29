using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace FileCounter
{
    /// <summary>
    /// 运行参数
    /// </summary>
    public class Config
    {
        // 源控制
        public string RootFolder { get; set; }
        public string[] Extensions { get; set; }
        public string Encoding { get; set; }
        public Encoding Enc
        {
            get
            {
                try   { return System.Text.Encoding.GetEncoding(this.Encoding); }
                catch { return System.Text.Encoding.UTF8; }
            }
        }

        // 辅助参数
        public string[] SkipSubFolders { get; set; }
        public bool SkipBlankLines { get; set; }
        public bool SkipCommentLines { get; set; }
        public bool SkipHidden { get; set; }

        // 输出控制
        public string OutFile { get; set; }
        public int OutLines { get; set; } = 9000;

        // 其它
        public bool OpenWhenFinished { get; set; }


        /// <summary>从 App.config 配置文件中读取</summary>
        public static Config ReadFromAppConfig()
        {
            var cfg = new Config();
            cfg.Extensions = ConfigurationManager.AppSettings["Extensions"].ToArray();
            cfg.SkipSubFolders = ConfigurationManager.AppSettings["SkipSubFolders"].ToArray();
            cfg.SkipHidden = ConfigurationManager.AppSettings["SkipHidden"].ToBool();
            cfg.SkipBlankLines = ConfigurationManager.AppSettings["SkipBlankLines"].ToBool();
            cfg.SkipCommentLines = ConfigurationManager.AppSettings["SkipCommentLines"].ToBool();
            cfg.OpenWhenFinished = ConfigurationManager.AppSettings["OpenWhenFinished"].ToBool();
            cfg.Encoding = ConfigurationManager.AppSettings["Encoding"];
            return cfg;
        }

    }
}
