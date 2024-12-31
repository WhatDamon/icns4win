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
            icnsutilGroupBox = new GroupBox();
            saveAndQuitBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            // 
            // icnsutilGroupBox
            // 
            icnsutilGroupBox.Location = new Point(12, 12);
            icnsutilGroupBox.Name = "icnsutilGroupBox";
            icnsutilGroupBox.Size = new Size(500, 213);
            icnsutilGroupBox.TabIndex = 0;
            icnsutilGroupBox.TabStop = false;
            icnsutilGroupBox.Text = "icnsutil";
            // 
            // saveAndQuitBtn
            // 
            saveAndQuitBtn.Location = new Point(367, 231);
            saveAndQuitBtn.Name = "saveAndQuitBtn";
            saveAndQuitBtn.Size = new Size(145, 34);
            saveAndQuitBtn.TabIndex = 1;
            saveAndQuitBtn.Text = "保存并退出";
            saveAndQuitBtn.UseVisualStyleBackColor = true;
            saveAndQuitBtn.Click += saveAndQuitBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(216, 231);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(145, 34);
            cancelBtn.TabIndex = 2;
            cancelBtn.Text = "取消";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // WndConfig
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 273);
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
            ResumeLayout(false);
        }

        #endregion

        private GroupBox icnsutilGroupBox;
        private Button saveAndQuitBtn;
        private Button cancelBtn;
    }
}