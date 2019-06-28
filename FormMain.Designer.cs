namespace FileMerger
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbExtensions = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.chkSkipBlankLines = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSkipCommentLines = new System.Windows.Forms.CheckBox();
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.lblApp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLines = new System.Windows.Forms.NumericUpDown();
            this.tbOutFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkOpenWhenFinished = new System.Windows.Forms.CheckBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.tbEncoding = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLines)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "源目录";
            // 
            // tbFolder
            // 
            this.tbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFolder.Location = new System.Drawing.Point(82, 114);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(561, 21);
            this.tbFolder.TabIndex = 1;
            // 
            // btnFolder
            // 
            this.btnFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolder.Location = new System.Drawing.Point(659, 112);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(75, 23);
            this.btnFolder.TabIndex = 2;
            this.btnFolder.Text = "设置";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "需处理的\r\n文件扩展名";
            // 
            // tbExtensions
            // 
            this.tbExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExtensions.Location = new System.Drawing.Point(82, 156);
            this.tbExtensions.Multiline = true;
            this.tbExtensions.Name = "tbExtensions";
            this.tbExtensions.Size = new System.Drawing.Size(652, 159);
            this.tbExtensions.TabIndex = 4;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(568, 499);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(659, 499);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // chkSkipBlankLines
            // 
            this.chkSkipBlankLines.AutoSize = true;
            this.chkSkipBlankLines.Location = new System.Drawing.Point(218, 458);
            this.chkSkipBlankLines.Name = "chkSkipBlankLines";
            this.chkSkipBlankLines.Size = new System.Drawing.Size(96, 16);
            this.chkSkipBlankLines.TabIndex = 7;
            this.chkSkipBlankLines.Text = "跳过连续空行";
            this.chkSkipBlankLines.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "选项";
            // 
            // chkSkipCommentLines
            // 
            this.chkSkipCommentLines.AutoSize = true;
            this.chkSkipCommentLines.Location = new System.Drawing.Point(354, 459);
            this.chkSkipCommentLines.Name = "chkSkipCommentLines";
            this.chkSkipCommentLines.Size = new System.Drawing.Size(108, 16);
            this.chkSkipCommentLines.TabIndex = 9;
            this.chkSkipCommentLines.Text = "跳过连续注释行";
            this.chkSkipCommentLines.UseVisualStyleBackColor = true;
            // 
            // picBanner
            // 
            this.picBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBanner.BackgroundImage")));
            this.picBanner.Location = new System.Drawing.Point(0, 0);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(747, 83);
            this.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBanner.TabIndex = 10;
            this.picBanner.TabStop = false;
            // 
            // lblApp
            // 
            this.lblApp.AutoSize = true;
            this.lblApp.BackColor = System.Drawing.Color.Transparent;
            this.lblApp.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApp.ForeColor = System.Drawing.Color.White;
            this.lblApp.Location = new System.Drawing.Point(22, 25);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(166, 27);
            this.lblApp.TabIndex = 11;
            this.lblApp.Text = "File Merger";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(338, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 12;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(194, 40);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(23, 12);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "1.0";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "输出行数";
            // 
            // tbLines
            // 
            this.tbLines.Location = new System.Drawing.Point(82, 417);
            this.tbLines.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tbLines.Name = "tbLines";
            this.tbLines.Size = new System.Drawing.Size(120, 21);
            this.tbLines.TabIndex = 15;
            this.tbLines.Value = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            // 
            // tbOutFile
            // 
            this.tbOutFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutFile.Location = new System.Drawing.Point(82, 376);
            this.tbOutFile.Name = "tbOutFile";
            this.tbOutFile.Size = new System.Drawing.Size(561, 21);
            this.tbOutFile.TabIndex = 17;
            this.tbOutFile.Text = "out.txt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "输出文件";
            // 
            // chkOpenWhenFinished
            // 
            this.chkOpenWhenFinished.AutoSize = true;
            this.chkOpenWhenFinished.Checked = true;
            this.chkOpenWhenFinished.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenWhenFinished.Location = new System.Drawing.Point(82, 458);
            this.chkOpenWhenFinished.Name = "chkOpenWhenFinished";
            this.chkOpenWhenFinished.Size = new System.Drawing.Size(84, 16);
            this.chkOpenWhenFinished.TabIndex = 18;
            this.chkOpenWhenFinished.Text = "完成时打开";
            this.chkOpenWhenFinished.UseVisualStyleBackColor = true;
            // 
            // btnFile
            // 
            this.btnFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFile.Location = new System.Drawing.Point(659, 374);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 19;
            this.btnFile.Text = "设置";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // tbEncoding
            // 
            this.tbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEncoding.Location = new System.Drawing.Point(82, 335);
            this.tbEncoding.Name = "tbEncoding";
            this.tbEncoding.Size = new System.Drawing.Size(652, 21);
            this.tbEncoding.TabIndex = 21;
            this.tbEncoding.Text = "UTF8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "字符集";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 534);
            this.Controls.Add(this.tbEncoding);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.chkOpenWhenFinished);
            this.Controls.Add(this.tbOutFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbLines);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblApp);
            this.Controls.Add(this.picBanner);
            this.Controls.Add(this.chkSkipCommentLines);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkSkipBlankLines);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.tbExtensions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.tbFolder);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileMerger";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbExtensions;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.CheckBox chkSkipBlankLines;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSkipCommentLines;
        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown tbLines;
        private System.Windows.Forms.TextBox tbOutFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkOpenWhenFinished;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox tbEncoding;
        private System.Windows.Forms.Label label6;
    }
}