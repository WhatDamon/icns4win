using icns4win.lib;
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

            // ��ʼ������
            InitializeComponent();
        }

        // ���ڼ����¼�
        private void WndMain_Load(object sender, EventArgs e)
        {
            checkForIcnsutil();
        }

        // ��� icnsutil �Ƿ����
        private void checkForIcnsutil()
        {
            string icnsutilName;
            string icnsutilFullPath;
            bool runWithPython = false;

            Misc.CommandLineParser.ParseCommand(BackendConfig.currentConfig.customArgs, out icnsutilFullPath, out icnsutilName, out runWithPython);

            if (!Path.Exists(icnsutilFullPath))
            {
                TaskDialogPage page = new TaskDialogPage()
                {
                    Icon = TaskDialogIcon.Warning,
                    Caption = "����",
                    Heading = $"δ�ҵ�: {icnsutilName}",
                    Text = $"��ת�������У����ǽ���ʹ���Ҳ������ļ���ȱ����������޷�����!",
                    Expander = new TaskDialogExpander()
                    {
                        Text = $"�������õ�������Ϊ: \n{BackendConfig.currentConfig.customArgs}\n���ҵ��ļ�Ϊ: \n{icnsutilFullPath}",
                    },
                    Buttons =
                    {
                        new TaskDialogCommandLinkButton("����Ԥ����汾", "���������Ѿ�Ԥ������ɵ� icnsutil �������ļ�, ��ʹ��Ĭ������")
                        {
                            Tag = 10
                        },
                        new TaskDialogCommandLinkButton("����", "���Ѿ��п��õ� icnsutil ��? �ڴ˴�����")
                        {
                            Tag = 20
                        },
                        TaskDialogButton.Retry,
                        TaskDialogButton.Close
                    },
                };
                TaskDialogButton result = TaskDialog.ShowDialog(this, page);

                if (result == TaskDialogButton.Retry)
                {
                    checkForIcnsutil();
                }
                else if (result == TaskDialogButton.Close)
                {
                    Application.Exit();
                }
                else if ((int)result.Tag == 10)
                {
                    MessageBox.Show("press ����Ԥ����汾");
                }
                else if ((int)result.Tag == 20)
                {
                    MessageBox.Show("press ����");
                }
            }
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
            checkForIcnsutil();
            Wrapper.ProcessIcns(filePathTextBox.Text, tempPath, false);
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

        // ���´���־��ť
        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // ���´���ʱĿ¼��ť
        private void openTempDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", tempPath);
        }
    }
}
