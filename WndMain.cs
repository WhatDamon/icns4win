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
                tempPath = Path.Combine(Path.GetTempPath(), $"icns4win{Process.GetCurrentProcess().Id}");
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

        // 打开文件
        private void moreFilePathBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "macOS 图标文件|*.icns|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = openFileDialog.FileName;
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

        // 点击解析按钮
        private void convertBtn_Click(object sender, EventArgs e)
        {
            
        }

        // 退出应用
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
