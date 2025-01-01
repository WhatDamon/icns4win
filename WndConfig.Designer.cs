namespace icns4win
{
    partial class WndConfig
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
            components = new System.ComponentModel.Container();
            icnsutilGroupBox = new GroupBox();
            compatibleLinkLabel = new LinkLabel();
            testArgsBtn = new Button();
            readyArgslabel = new Label();
            readyArgsComboBox = new ComboBox();
            keysArgTextBox = new TextBox();
            argsDescriptionLabel = new Label();
            argsLabel = new Label();
            argsTextBox = new TextBox();
            supportKeysRenameCheckBox = new CheckBox();
            saveAndQuitBtn = new Button();
            cancelBtn = new Button();
            setToDefaultBtn = new Button();
            argsErrorProvider = new ErrorProvider(components);
            icnsutilGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)argsErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // icnsutilGroupBox
            // 
            icnsutilGroupBox.Controls.Add(compatibleLinkLabel);
            icnsutilGroupBox.Controls.Add(testArgsBtn);
            icnsutilGroupBox.Controls.Add(readyArgslabel);
            icnsutilGroupBox.Controls.Add(readyArgsComboBox);
            icnsutilGroupBox.Controls.Add(keysArgTextBox);
            icnsutilGroupBox.Controls.Add(argsDescriptionLabel);
            icnsutilGroupBox.Controls.Add(argsLabel);
            icnsutilGroupBox.Controls.Add(argsTextBox);
            icnsutilGroupBox.Controls.Add(supportKeysRenameCheckBox);
            icnsutilGroupBox.Location = new Point(12, 12);
            icnsutilGroupBox.Name = "icnsutilGroupBox";
            icnsutilGroupBox.Size = new Size(500, 211);
            icnsutilGroupBox.TabIndex = 2;
            icnsutilGroupBox.TabStop = false;
            icnsutilGroupBox.Text = "icnsutil 参数";
            // 
            // compatibleLinkLabel
            // 
            compatibleLinkLabel.ActiveLinkColor = SystemColors.HotTrack;
            compatibleLinkLabel.AutoSize = true;
            compatibleLinkLabel.Font = new Font("Microsoft YaHei UI", 8F);
            compatibleLinkLabel.LinkColor = SystemColors.Highlight;
            compatibleLinkLabel.Location = new Point(96, 145);
            compatibleLinkLabel.Name = "compatibleLinkLabel";
            compatibleLinkLabel.Size = new Size(307, 21);
            compatibleLinkLabel.TabIndex = 6;
            compatibleLinkLabel.TabStop = true;
            compatibleLinkLabel.Text = "兼容 https://github.com/relikd/icnsutil/";
            compatibleLinkLabel.VisitedLinkColor = SystemColors.Highlight;
            compatibleLinkLabel.LinkClicked += compatibleLinkLabel_LinkClicked;
            // 
            // testArgsBtn
            // 
            testArgsBtn.Location = new Point(346, 28);
            testArgsBtn.Name = "testArgsBtn";
            testArgsBtn.Size = new Size(132, 34);
            testArgsBtn.TabIndex = 4;
            testArgsBtn.Text = "测试是否工作";
            testArgsBtn.UseVisualStyleBackColor = true;
            // 
            // readyArgslabel
            // 
            readyArgslabel.AutoSize = true;
            readyArgslabel.Location = new Point(40, 32);
            readyArgslabel.Name = "readyArgslabel";
            readyArgslabel.Size = new Size(50, 24);
            readyArgslabel.TabIndex = 7;
            readyArgslabel.Text = "预设:";
            // 
            // readyArgsComboBox
            // 
            readyArgsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            readyArgsComboBox.FormattingEnabled = true;
            readyArgsComboBox.Items.AddRange(new object[] { "直接调用 icnsutil", "使用 Python 调用 icnsutil", "自定义" });
            readyArgsComboBox.Location = new Point(96, 29);
            readyArgsComboBox.Name = "readyArgsComboBox";
            readyArgsComboBox.Size = new Size(253, 32);
            readyArgsComboBox.TabIndex = 3;
            readyArgsComboBox.SelectedIndexChanged += readyArgsComboBox_SelectedIndexChanged;
            // 
            // keysArgTextBox
            // 
            keysArgTextBox.Location = new Point(322, 175);
            keysArgTextBox.Name = "keysArgTextBox";
            keysArgTextBox.Size = new Size(156, 30);
            keysArgTextBox.TabIndex = 8;
            // 
            // argsDescriptionLabel
            // 
            argsDescriptionLabel.AutoSize = true;
            argsDescriptionLabel.Font = new Font("Microsoft YaHei UI", 7.5F, FontStyle.Italic, GraphicsUnit.Point, 134);
            argsDescriptionLabel.ForeColor = SystemColors.ControlDarkDark;
            argsDescriptionLabel.Location = new Point(96, 101);
            argsDescriptionLabel.Name = "argsDescriptionLabel";
            argsDescriptionLabel.Size = new Size(375, 40);
            argsDescriptionLabel.TabIndex = 3;
            argsDescriptionLabel.Text = "{source} 代表传递的文件路径，{export} 代表输出目录\r\n示例: icnsutil extract {source} --export-dir {export}";
            // 
            // argsLabel
            // 
            argsLabel.AutoSize = true;
            argsLabel.Location = new Point(6, 71);
            argsLabel.Name = "argsLabel";
            argsLabel.Size = new Size(86, 24);
            argsLabel.TabIndex = 2;
            argsLabel.Text = "传递参数:";
            // 
            // argsTextBox
            // 
            argsTextBox.Location = new Point(96, 68);
            argsTextBox.Name = "argsTextBox";
            argsTextBox.Size = new Size(382, 30);
            argsTextBox.TabIndex = 5;
            argsTextBox.TextChanged += argsTextBox_TextChanged;
            argsTextBox.Validating += argsTextBox_Validating;
            // 
            // supportKeysRenameCheckBox
            // 
            supportKeysRenameCheckBox.AutoSize = true;
            supportKeysRenameCheckBox.Checked = true;
            supportKeysRenameCheckBox.CheckState = CheckState.Checked;
            supportKeysRenameCheckBox.Location = new Point(6, 177);
            supportKeysRenameCheckBox.Name = "supportKeysRenameCheckBox";
            supportKeysRenameCheckBox.Size = new Size(310, 28);
            supportKeysRenameCheckBox.TabIndex = 7;
            supportKeysRenameCheckBox.Text = "支持重命名为键，使用它应当传递:";
            supportKeysRenameCheckBox.UseVisualStyleBackColor = true;
            supportKeysRenameCheckBox.CheckedChanged += supportKeysRenameCheckBox_CheckedChanged;
            // 
            // saveAndQuitBtn
            // 
            saveAndQuitBtn.Location = new Point(367, 229);
            saveAndQuitBtn.Name = "saveAndQuitBtn";
            saveAndQuitBtn.Size = new Size(145, 34);
            saveAndQuitBtn.TabIndex = 1;
            saveAndQuitBtn.Text = "保存并退出";
            saveAndQuitBtn.UseVisualStyleBackColor = true;
            saveAndQuitBtn.Click += saveAndQuitBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(216, 229);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(145, 34);
            cancelBtn.TabIndex = 2;
            cancelBtn.Text = "取消";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // setToDefaultBtn
            // 
            setToDefaultBtn.Location = new Point(12, 229);
            setToDefaultBtn.Name = "setToDefaultBtn";
            setToDefaultBtn.Size = new Size(112, 34);
            setToDefaultBtn.TabIndex = 6;
            setToDefaultBtn.Text = "恢复默认";
            setToDefaultBtn.UseVisualStyleBackColor = true;
            // 
            // argsErrorProvider
            // 
            argsErrorProvider.BlinkRate = 500;
            argsErrorProvider.ContainerControl = this;
            // 
            // WndConfig
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 275);
            Controls.Add(setToDefaultBtn);
            Controls.Add(cancelBtn);
            Controls.Add(saveAndQuitBtn);
            Controls.Add(icnsutilGroupBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WndConfig";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "配置";
            icnsutilGroupBox.ResumeLayout(false);
            icnsutilGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)argsErrorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox icnsutilGroupBox;
        private Button saveAndQuitBtn;
        private Button cancelBtn;
        private CheckBox supportKeysRenameCheckBox;
        private Label argsLabel;
        private TextBox argsTextBox;
        private Label argsDescriptionLabel;
        private TextBox keysArgTextBox;
        private Button setToDefaultBtn;
        private ErrorProvider argsErrorProvider;
        private Label readyArgslabel;
        private ComboBox readyArgsComboBox;
        private Button testArgsBtn;
        private LinkLabel compatibleLinkLabel;
    }
}