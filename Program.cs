using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Windows.Forms;

namespace FileCounter
{

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Logger.Log("-----------------------------------------");
            Logger.Log("FileCounter");
            Logger.Log("Version {0}", Helper.GetVersion());
            Logger.Log("https://www.github.com/surfsky/");
            Logger.Log("2024-04");
            Logger.Log("-----------------------------------------");


            if (args.Length == 0)
                Application.Run(new FormMain());
            else
            {
                var cfg = Config.ReadFromAppConfig();
                cfg.RootFolder = args[0];
                cfg.OutFile = args[1];
                cfg.OutLines = Convert.ToInt32(args[2]);
                Scanner.Run(cfg);
            }
        }

    }
}
