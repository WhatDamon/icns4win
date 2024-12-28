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
            // ������ʱĿ¼
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

        // ���ļ�
        private void moreFilePathBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "macOS ͼ���ļ�|*.icns|�����ļ�|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = openFileDialog.FileName;
            }
        }

        // �ļ�·���ı�
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

        // ���������ť
        private void convertBtn_Click(object sender, EventArgs e)
        {
            
        }

        // �˳�Ӧ��
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
