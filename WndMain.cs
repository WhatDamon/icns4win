using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;

namespace icns4win
{
    public partial class WndMain : Form
    {
        private string tempPath = "";
        private string configPath = Path.Combine(Application.StartupPath, "config.json");

        public WndMain()
        {
            // ��ʼ�������ļ�
            if (!BackendConfig.InitConfig(configPath))
            {
                MessageBox.Show("�����ļ���ʼ��ʧ�ܣ����������ļ���ʽ�Ƿ���ȷ\n���Ƿ��ж�дȨ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

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
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (tempPath != null)
            {
                // ɾ����ʱĿ¼
                try
                {
                    Directory.Delete(tempPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        // ����
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskDialogPage page = new TaskDialogPage()
            {
                Text = "Apple Icon Image Format �� Windows �µĴ�����\n" +
                $"�汾: {Assembly.GetExecutingAssembly().GetName().Version}\n" +
                "���û������� What_Damon ����\n" +
                "ʹ�� MIT ���֤��Դ\n" +
                $".NET�汾: {Environment.Version.ToString()}",
                Heading = "���� icns4win",
                Caption = "����",
                Icon = TaskDialogIcon.Information,
                DefaultButton = TaskDialogButton.OK,
                Buttons = { TaskDialogButton.OK }
            };

            TaskDialogButton result = TaskDialog.ShowDialog(this, page);
        }

        // ���� GitHub �ֿⰴť
        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/WhatDamon/icns4win");
        }
    }
}
