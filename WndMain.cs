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

        // ���ļ����ı���
        private bool openFile2TextBox()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "macOS ͼ���ļ�|*.icns|�����ļ�|*.*";
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

        // ���´��ļ���ť
        private void moreFilePathBtn_Click(object sender, EventArgs e)
        {
            openFile2TextBox();
        }

        // ���´��ļ��˵�
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFile2TextBox())
            {
                convertBtn.PerformClick();
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

        // ���½�����ť
        private void convertBtn_Click(object sender, EventArgs e)
        {

        }

        // �˳�Ӧ��
        private void closeApp()
        {
            // ɾ����ʱĿ¼
            try
            {
                Directory.Delete(tempPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // �˳�Ӧ�ñ����
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WndMain_FormClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, false));
        }

        // ���ڹر�
        private void WndMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeApp();
        }

        // �������ð�ť
        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WndConfig wndConfig = new WndConfig();
            wndConfig.Owner = this;
            wndConfig.ShowDialog();
        }
    }
}
