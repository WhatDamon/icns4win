namespace icns4win
{
    partial class WndMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            configToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            gitHubToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            statusToolStripStatusLabel = new ToolStripStatusLabel();
            currentStatusStripStatusLabel = new ToolStripStatusLabel();
            previewGroupBox = new GroupBox();
            previewStatusLabel = new Label();
            previewPictureBox = new PictureBox();
            filePathLabel = new Label();
            filePathTextBox = new TextBox();
            moreFilePathBtn = new Button();
            convertBtn = new Button();
            actionsGroupBox = new GroupBox();
            convertJp2ToPngCheckBox = new CheckBox();
            renameWithKeysCheckBox = new CheckBox();
            saveBinCheckBox = new CheckBox();
            saveArgbCheckBox = new CheckBox();
            saveRgbCheckBox = new CheckBox();
            savePlistCheckBox = new CheckBox();
            saveJp2CheckBox = new CheckBox();
            savePngCheckBox = new CheckBox();
            clearBtn = new Button();
            saveAllBtn = new Button();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            previewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).BeginInit();
            actionsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(627, 32);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, configToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(84, 28);
            fileToolStripMenuItem.Text = "文件(&F)";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(215, 34);
            openToolStripMenuItem.Text = "打开";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // configToolStripMenuItem
            // 
            configToolStripMenuItem.Name = "configToolStripMenuItem";
            configToolStripMenuItem.Size = new Size(215, 34);
            configToolStripMenuItem.Text = "配置";
            configToolStripMenuItem.Click += configToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(212, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(215, 34);
            exitToolStripMenuItem.Text = "退出";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gitHubToolStripMenuItem, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(88, 28);
            helpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // gitHubToolStripMenuItem
            // 
            gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            gitHubToolStripMenuItem.Size = new Size(270, 34);
            gitHubToolStripMenuItem.Text = "GitHub 仓库";
            gitHubToolStripMenuItem.Click += gitHubToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(270, 34);
            aboutToolStripMenuItem.Text = "关于";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusToolStripStatusLabel, currentStatusStripStatusLabel });
            statusStrip.Location = new Point(0, 430);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(627, 32);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 3;
            statusStrip.Text = "statusStrip";
            // 
            // statusToolStripStatusLabel
            // 
            statusToolStripStatusLabel.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
            statusToolStripStatusLabel.Size = new Size(58, 25);
            statusToolStripStatusLabel.Text = "状态: ";
            // 
            // currentStatusStripStatusLabel
            // 
            currentStatusStripStatusLabel.Name = "currentStatusStripStatusLabel";
            currentStatusStripStatusLabel.Size = new Size(46, 25);
            currentStatusStripStatusLabel.Text = "就绪";
            // 
            // previewGroupBox
            // 
            previewGroupBox.Controls.Add(previewStatusLabel);
            previewGroupBox.Controls.Add(previewPictureBox);
            previewGroupBox.Location = new Point(347, 35);
            previewGroupBox.Name = "previewGroupBox";
            previewGroupBox.Size = new Size(269, 388);
            previewGroupBox.TabIndex = 10;
            previewGroupBox.TabStop = false;
            previewGroupBox.Text = "预览";
            // 
            // previewStatusLabel
            // 
            previewStatusLabel.AutoSize = true;
            previewStatusLabel.Font = new Font("Microsoft YaHei UI", 6F);
            previewStatusLabel.Location = new Point(6, 292);
            previewStatusLabel.Name = "previewStatusLabel";
            previewStatusLabel.Size = new Size(127, 85);
            previewStatusLabel.TabIndex = 10;
            previewStatusLabel.Text = "统计信息:\r\nPNG 与 JP2图片: --\r\nRGB 与 ARGB文件: --\r\nBIN 文件: --\r\n信息文件: --";
            // 
            // previewPictureBox
            // 
            previewPictureBox.Location = new Point(6, 29);
            previewPictureBox.Name = "previewPictureBox";
            previewPictureBox.Size = new Size(256, 256);
            previewPictureBox.TabIndex = 3;
            previewPictureBox.TabStop = false;
            // 
            // filePathLabel
            // 
            filePathLabel.AutoSize = true;
            filePathLabel.Location = new Point(12, 35);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new Size(86, 24);
            filePathLabel.TabIndex = 1;
            filePathLabel.Text = "选择文件:";
            // 
            // filePathTextBox
            // 
            filePathTextBox.Location = new Point(12, 62);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.Size = new Size(290, 30);
            filePathTextBox.TabIndex = 1;
            filePathTextBox.TextChanged += filePathTextBox_TextChanged;
            // 
            // moreFilePathBtn
            // 
            moreFilePathBtn.Location = new Point(304, 60);
            moreFilePathBtn.Name = "moreFilePathBtn";
            moreFilePathBtn.Size = new Size(37, 34);
            moreFilePathBtn.TabIndex = 2;
            moreFilePathBtn.Text = "...";
            moreFilePathBtn.UseVisualStyleBackColor = true;
            moreFilePathBtn.Click += moreFilePathBtn_Click;
            // 
            // convertBtn
            // 
            convertBtn.Enabled = false;
            convertBtn.Location = new Point(12, 98);
            convertBtn.Name = "convertBtn";
            convertBtn.Size = new Size(112, 34);
            convertBtn.TabIndex = 3;
            convertBtn.Text = "解析";
            convertBtn.UseVisualStyleBackColor = true;
            convertBtn.Click += convertBtn_Click;
            // 
            // actionsGroupBox
            // 
            actionsGroupBox.Controls.Add(convertJp2ToPngCheckBox);
            actionsGroupBox.Controls.Add(renameWithKeysCheckBox);
            actionsGroupBox.Controls.Add(saveBinCheckBox);
            actionsGroupBox.Controls.Add(saveArgbCheckBox);
            actionsGroupBox.Controls.Add(saveRgbCheckBox);
            actionsGroupBox.Controls.Add(savePlistCheckBox);
            actionsGroupBox.Controls.Add(saveJp2CheckBox);
            actionsGroupBox.Controls.Add(savePngCheckBox);
            actionsGroupBox.Controls.Add(clearBtn);
            actionsGroupBox.Controls.Add(saveAllBtn);
            actionsGroupBox.Enabled = false;
            actionsGroupBox.Location = new Point(12, 138);
            actionsGroupBox.Name = "actionsGroupBox";
            actionsGroupBox.Size = new Size(329, 285);
            actionsGroupBox.TabIndex = 4;
            actionsGroupBox.TabStop = false;
            actionsGroupBox.Text = "操作";
            // 
            // convertJp2ToPngCheckBox
            // 
            convertJp2ToPngCheckBox.AutoSize = true;
            convertJp2ToPngCheckBox.Checked = true;
            convertJp2ToPngCheckBox.CheckState = CheckState.Checked;
            convertJp2ToPngCheckBox.Enabled = false;
            convertJp2ToPngCheckBox.Location = new Point(156, 165);
            convertJp2ToPngCheckBox.Name = "convertJp2ToPngCheckBox";
            convertJp2ToPngCheckBox.Size = new Size(168, 28);
            convertJp2ToPngCheckBox.TabIndex = 11;
            convertJp2ToPngCheckBox.Text = "JP2 转换成 PNG";
            convertJp2ToPngCheckBox.UseVisualStyleBackColor = true;
            // 
            // renameWithKeysCheckBox
            // 
            renameWithKeysCheckBox.AutoSize = true;
            renameWithKeysCheckBox.Enabled = false;
            renameWithKeysCheckBox.Location = new Point(6, 165);
            renameWithKeysCheckBox.Name = "renameWithKeysCheckBox";
            renameWithKeysCheckBox.Size = new Size(144, 28);
            renameWithKeysCheckBox.TabIndex = 10;
            renameWithKeysCheckBox.Text = "键名命名文件";
            renameWithKeysCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveBinCheckBox
            // 
            saveBinCheckBox.AutoSize = true;
            saveBinCheckBox.Enabled = false;
            saveBinCheckBox.Location = new Point(6, 131);
            saveBinCheckBox.Name = "saveBinCheckBox";
            saveBinCheckBox.Size = new Size(275, 28);
            saveBinCheckBox.TabIndex = 9;
            saveBinCheckBox.Text = "输出 BIN(包括TOC、Mask等)";
            saveBinCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveArgbCheckBox
            // 
            saveArgbCheckBox.AutoSize = true;
            saveArgbCheckBox.Enabled = false;
            saveArgbCheckBox.Location = new Point(6, 97);
            saveArgbCheckBox.Name = "saveArgbCheckBox";
            saveArgbCheckBox.Size = new Size(126, 28);
            saveArgbCheckBox.TabIndex = 8;
            saveArgbCheckBox.Text = "输出 ARGB";
            saveArgbCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveRgbCheckBox
            // 
            saveRgbCheckBox.AutoSize = true;
            saveRgbCheckBox.Enabled = false;
            saveRgbCheckBox.Location = new Point(6, 63);
            saveRgbCheckBox.Name = "saveRgbCheckBox";
            saveRgbCheckBox.Size = new Size(113, 28);
            saveRgbCheckBox.TabIndex = 6;
            saveRgbCheckBox.Text = "输出 RGB";
            saveRgbCheckBox.UseVisualStyleBackColor = true;
            // 
            // savePlistCheckBox
            // 
            savePlistCheckBox.AutoSize = true;
            savePlistCheckBox.Enabled = false;
            savePlistCheckBox.Location = new Point(125, 63);
            savePlistCheckBox.Name = "savePlistCheckBox";
            savePlistCheckBox.Size = new Size(193, 28);
            savePlistCheckBox.TabIndex = 7;
            savePlistCheckBox.Text = "输出其他信息(plist)";
            savePlistCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveJp2CheckBox
            // 
            saveJp2CheckBox.AutoSize = true;
            saveJp2CheckBox.Checked = true;
            saveJp2CheckBox.CheckState = CheckState.Checked;
            saveJp2CheckBox.Enabled = false;
            saveJp2CheckBox.Location = new Point(125, 29);
            saveJp2CheckBox.Name = "saveJp2CheckBox";
            saveJp2CheckBox.Size = new Size(167, 28);
            saveJp2CheckBox.TabIndex = 5;
            saveJp2CheckBox.Text = "输出 JPEG 2000";
            saveJp2CheckBox.UseVisualStyleBackColor = true;
            // 
            // savePngCheckBox
            // 
            savePngCheckBox.AutoSize = true;
            savePngCheckBox.Checked = true;
            savePngCheckBox.CheckState = CheckState.Checked;
            savePngCheckBox.Enabled = false;
            savePngCheckBox.Location = new Point(6, 29);
            savePngCheckBox.Name = "savePngCheckBox";
            savePngCheckBox.Size = new Size(116, 28);
            savePngCheckBox.TabIndex = 4;
            savePngCheckBox.Text = "输出 PNG";
            savePngCheckBox.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            clearBtn.ForeColor = Color.Red;
            clearBtn.Location = new Point(6, 245);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(317, 34);
            clearBtn.TabIndex = 13;
            clearBtn.Text = "清空";
            clearBtn.UseVisualStyleBackColor = true;
            // 
            // saveAllBtn
            // 
            saveAllBtn.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            saveAllBtn.Location = new Point(6, 205);
            saveAllBtn.Name = "saveAllBtn";
            saveAllBtn.Size = new Size(317, 34);
            saveAllBtn.TabIndex = 12;
            saveAllBtn.Text = "保存全部";
            saveAllBtn.UseVisualStyleBackColor = true;
            // 
            // WndMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 462);
            Controls.Add(actionsGroupBox);
            Controls.Add(convertBtn);
            Controls.Add(moreFilePathBtn);
            Controls.Add(filePathTextBox);
            Controls.Add(filePathLabel);
            Controls.Add(previewGroupBox);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WndMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "icns4win";
            FormClosing += WndMain_FormClosing;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            previewGroupBox.ResumeLayout(false);
            previewGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).EndInit();
            actionsGroupBox.ResumeLayout(false);
            actionsGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusToolStripStatusLabel;
        private ToolStripStatusLabel currentStatusStripStatusLabel;
        private GroupBox previewGroupBox;
        private PictureBox previewPictureBox;
        private Label previewStatusLabel;
        private Label filePathLabel;
        private TextBox filePathTextBox;
        private Button moreFilePathBtn;
        private Button convertBtn;
        private GroupBox actionsGroupBox;
        private Button saveAllBtn;
        private CheckBox savePngCheckBox;
        private Button clearBtn;
        private ToolStripMenuItem configToolStripMenuItem;
        private CheckBox saveArgbCheckBox;
        private CheckBox saveRgbCheckBox;
        private CheckBox savePlistCheckBox;
        private CheckBox saveJp2CheckBox;
        private CheckBox convertJp2ToPngCheckBox;
        private CheckBox renameWithKeysCheckBox;
        private CheckBox saveBinCheckBox;
        private ToolStripMenuItem gitHubToolStripMenuItem;
    }
}
