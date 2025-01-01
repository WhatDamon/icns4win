using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace icns4win
{
    public partial class WndConfig : Form
    {
        public WndConfig()
        {
            InitializeComponent();
        }

        // 按下保存并关闭按钮
        private void saveAndQuitBtn_Click(object sender, EventArgs e)
        {

        }

        // 勾选是否支持键名重命名
        private void supportKeysRenameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (supportKeysRenameCheckBox.Checked)
            {
                keysArgTextBox.Enabled = true;
            }
            else
            {
                keysArgTextBox.Enabled = false;
            }
        }

        // 当用户离开参数文本框时的内容验证
        private void argsTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(argsTextBox.Text))
            {
                argsErrorProvider.SetError(argsTextBox, "内容不得为空!");
                saveAndQuitBtn.Enabled = false;
            }
            else if (!argsTextBox.Text.Contains("{source}") || !argsTextBox.Text.Contains("{export}"))
            {
                argsErrorProvider.SetError(argsTextBox, "内容必须包含 {source} 和 {export}!");
                saveAndQuitBtn.Enabled = false;
            }
            else
            {
                argsErrorProvider.Clear();
                saveAndQuitBtn.Enabled = true;
            }
        }

        private void compatibleLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/relikd/icnsutil/");
        }
    }
}
