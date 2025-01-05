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
            // 初始化配置文件
            if (!BackendConfig.InitConfig(configPath))
            {
                MessageBox.Show("配置文件初始化失败，请检查配置文件格式是否正确\n或是否有读写权限", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

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
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 初始化窗口
            InitializeComponent();
        }

        // 窗口加载事件
        private void WndMain_Load(object sender, EventArgs e)
        {
            checkForIcnsutil();
        }

        // 检查 icnsutil 是否存在
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
                    Caption = "警告",
                    Heading = $"未找到: {icnsutilName}",
                    Text = $"在转换过程中，我们将会使用找不到的文件，缺少它软件将无法工作!",
                    Expander = new TaskDialogExpander()
                    {
                        Text = $"您所配置的命令行为: \n{BackendConfig.currentConfig.customArgs}\n查找的文件为: \n{icnsutilFullPath}",
                    },
                    Buttons =
                    {
                        new TaskDialogCommandLinkButton("下载预编译版本", "这里下载已经预编译完成的 icnsutil 二进制文件, 并使用默认配置")
                        {
                            Tag = 10
                        },
                        new TaskDialogCommandLinkButton("配置", "您已经有可用的 icnsutil 了? 在此处配置")
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
                    MessageBox.Show("press 下载预编译版本");
                }
                else if ((int)result.Tag == 20)
                {
                    MessageBox.Show("press 配置");
                }
            }
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
            checkForIcnsutil();
            Wrapper.ProcessIcns(filePathTextBox.Text, tempPath, false);
        }

        // 退出应用
        private void closeApp()
        {
            if (tempPath != null)
            {
                // 删除临时目录
                try
                {
                    Directory.Delete(tempPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        // 关于
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskDialogPage page = new TaskDialogPage()
            {
                Text = "Apple Icon Image Format 在 Windows 下的处理工具\n" +
                $"版本: {Assembly.GetExecutingAssembly().GetName().Version}\n" +
                "该用户界面由 What_Damon 开发\n" +
                "使用 MIT 许可证开源\n" +
                $".NET版本: {Environment.Version.ToString()}",
                Heading = "关于 icns4win",
                Caption = "关于",
                Icon = TaskDialogIcon.Information,
                DefaultButton = TaskDialogButton.OK,
                Buttons = { TaskDialogButton.OK }
            };

            TaskDialogButton result = TaskDialog.ShowDialog(this, page);
        }

        // 按下 GitHub 仓库按钮
        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/WhatDamon/icns4win");
        }

        // 按下打开日志按钮
        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // 按下打开临时目录按钮
        private void openTempDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", tempPath);
        }
    }
}
