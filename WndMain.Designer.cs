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
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
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
            checkBox1 = new CheckBox();
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
            menuStrip.Size = new Size(694, 32);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
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
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(88, 28);
            helpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(146, 34);
            aboutToolStripMenuItem.Text = "关于";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusToolStripStatusLabel, currentStatusStripStatusLabel });
            statusStrip.Location = new Point(0, 365);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(694, 32);
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
            previewGroupBox.Location = new Point(413, 35);
            previewGroupBox.Name = "previewGroupBox";
            previewGroupBox.Size = new Size(269, 326);
            previewGroupBox.TabIndex = 10;
            previewGroupBox.TabStop = false;
            previewGroupBox.Text = "预览";
            // 
            // previewStatusLabel
            // 
            previewStatusLabel.AutoSize = true;
            previewStatusLabel.Location = new Point(6, 292);
            previewStatusLabel.Name = "previewStatusLabel";
            previewStatusLabel.Size = new Size(143, 24);
            previewStatusLabel.TabIndex = 10;
            previewStatusLabel.Text = "请提供 icns 图标";
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
            filePathTextBox.Size = new Size(359, 30);
            filePathTextBox.TabIndex = 1;
            filePathTextBox.TextChanged += filePathTextBox_TextChanged;
            // 
            // moreFilePathBtn
            // 
            moreFilePathBtn.Location = new Point(370, 60);
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
            actionsGroupBox.Controls.Add(checkBox1);
            actionsGroupBox.Controls.Add(clearBtn);
            actionsGroupBox.Controls.Add(saveAllBtn);
            actionsGroupBox.Enabled = false;
            actionsGroupBox.Location = new Point(12, 138);
            actionsGroupBox.Name = "actionsGroupBox";
            actionsGroupBox.Size = new Size(395, 223);
            actionsGroupBox.TabIndex = 4;
            actionsGroupBox.TabStop = false;
            actionsGroupBox.Text = "操作";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 29);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(129, 28);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "只输出PNG";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            clearBtn.ForeColor = Color.Red;
            clearBtn.Location = new Point(6, 179);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(383, 34);
            clearBtn.TabIndex = 9;
            clearBtn.Text = "清空";
            clearBtn.UseVisualStyleBackColor = true;
            // 
            // saveAllBtn
            // 
            saveAllBtn.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            saveAllBtn.Location = new Point(6, 139);
            saveAllBtn.Name = "saveAllBtn";
            saveAllBtn.Size = new Size(383, 34);
            saveAllBtn.TabIndex = 8;
            saveAllBtn.Text = "保存全部";
            saveAllBtn.UseVisualStyleBackColor = true;
            // 
            // WndMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 397);
            Controls.Add(actionsGroupBox);
            Controls.Add(convertBtn);
            Controls.Add(moreFilePathBtn);
            Controls.Add(filePathTextBox);
            Controls.Add(filePathLabel);
            Controls.Add(previewGroupBox);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MainMenuStrip = menuStrip;
            Name = "WndMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "icns4win";
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
        private CheckBox checkBox1;
        private Button clearBtn;
    }
}
