using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;

namespace icns4win
{
    public partial class WndMain : Form
    {
        private string tempPath = "";

        public WndMain()
        {
            // 创建临时目录
            try
            {
                Guid guid = Guid.NewGuid();
                tempPath = Path.Combine(Path.GetTempPath(), $"{guid.ToString()}.icns4win");
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                else
                {
                    Directory.Delete(tempPath, true);
                    Directory.CreateDirectory(tempPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            InitializeComponent();
        }

        // 打开文件到文本框
        private bool openFile2TextBox()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "macOS 图标文件|*.icns|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = openFileDialog.FileName;
                return true;
            }
            else
            {
                return false;
            }

        }

        // 按下打开文件按钮
        private void moreFilePathBtn_Click(object sender, EventArgs e)
        {
            openFile2TextBox();
        }

        // 按下打开文件菜单
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFile2TextBox())
            {
                convertBtn.PerformClick();
            }
        }

        // 文件路径改变
        private void filePathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Path.Exists(filePathTextBox.Text))
            {
                convertBtn.Enabled = true;
            }
            else
            {
                convertBtn.Enabled = false;
            }
        }

        // 按下解析按钮
        private void convertBtn_Click(object sender, EventArgs e)
        {

        }

        // 退出应用
        private void closeApp()
        {
            // 删除临时目录
            try
            {
                Directory.Delete(tempPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 退出应用被点击
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WndMain_FormClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }

        // 窗口关闭
        private void WndMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeApp();
        }

        // 按下配置按钮
        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WndConfig wndConfig = new WndConfig();
            wndConfig.Owner = this;
            wndConfig.ShowDialog();
        }
    }
}
