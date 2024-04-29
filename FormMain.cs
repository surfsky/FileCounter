using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCounter
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.lblApp.BackColor = Color.Transparent;
            this.lblApp.Parent = picBanner;
            this.lblVersion.Text = Helper.GetVersion();
            this.lblVersion.BackColor = Color.Transparent;
            this.lblVersion.Parent = picBanner;

            //
            var cfg = Config.ReadFromAppConfig();
            this.tbEncoding.Text = cfg.Encoding;
            this.tbExtensions.Text = cfg.Extensions.ToSeparatedString();
            this.tbSkipSubFolders.Text = cfg.SkipSubFolders.ToSeparatedString();
            this.chkSkipHidden.Checked = cfg.SkipHidden;
            this.chkSkipBlankLines.Checked = cfg.SkipBlankLines;
            this.chkSkipCommentLines.Checked = cfg.SkipCommentLines;
            this.chkOpenWhenFinished.Checked = cfg.OpenWhenFinished;
        }

        // 设置源程序目录
        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = Application.StartupPath + "\\test\\";
            if (dlg.ShowDialog() == DialogResult.OK)
                this.tbFolder.Text = dlg.SelectedPath;
        }


        // 设置输出文件路径
        private void btnFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (!tbOutFile.Text.IsEmpty())
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(this.tbOutFile.Text);
                dlg.InitialDirectory = fi.DirectoryName;
                dlg.FileName = fi.Name;
            }
            if (dlg.ShowDialog() == DialogResult.OK)
                this.tbOutFile.Text = dlg.FileName;
        }

        // 显示关于
        private void btnAbout_Click(object sender, EventArgs e)
        {
            var about = ConfigurationManager.AppSettings["About"];
            MessageBox.Show(about, "关于");
        }

        // 启动控制台进行输出运算
        private void btnGo_Click(object sender, EventArgs e)
        {
            var cfg = new Config();
            cfg.RootFolder = this.tbFolder.Text;
            cfg.Encoding = this.tbEncoding.Text;
            cfg.Extensions = this.tbExtensions.Text.ToArray();
            cfg.SkipBlankLines = this.chkSkipBlankLines.Checked;
            cfg.SkipCommentLines = this.chkSkipCommentLines.Checked;
            cfg.SkipSubFolders = this.tbSkipSubFolders.Text.ToArray();
            cfg.SkipHidden = this.chkSkipHidden.Checked;
            cfg.OpenWhenFinished = this.chkOpenWhenFinished.Checked;
            cfg.OutFile = this.tbOutFile.Text;
            cfg.OutLines = (int)this.tbLines.Value;
            Scanner.Run(cfg);
        }

    }
}
