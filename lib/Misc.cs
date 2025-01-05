using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace icns4win.lib
{
    internal class Misc
    {
        /// <summary>
        /// 命令行参数解析器
        /// </summary>
        public class CommandLineParser
        {
            private static string[] SplitCommandLine(string command)
            {
                List<string> args = new List<string>();
                bool inQuotes = false;
                int start = 0;
                for (int i = 0; i < command.Length; i++)
                {
                    if (command[i] == '"' && (i == 0 || command[i - 1] != '\\'))
                    {
                        inQuotes = !inQuotes;
                    }
                    else if (!inQuotes && char.IsWhiteSpace(command[i]))
                    {
                        if (start < i)
                        {
                            args.Add(command.Substring(start, i - start).Trim('"').Trim());
                        }
                        start = i + 1;
                    }
                }

                if (start < command.Length)
                {
                    args.Add(command.Substring(start).Trim('"').Trim());
                }

                return args.ToArray();
            }

            public static void ParseCommand(string command, out string fullPath, out string filename, out bool runWithPython)
            {
                // 使用改进的方法分割命令参数
                var args = SplitCommandLine(command);

                // 查找 python 可执行文件位置
                int pythonIndex = Array.FindIndex(args, s => s.Contains("python", StringComparison.OrdinalIgnoreCase));

                if (pythonIndex >= 0 && args.Length > pythonIndex + 1)
                {
                    // 获取脚本路径
                    string scriptPath = args[pythonIndex + 1];

                    // 判断是否为绝对路径
                    if (Path.IsPathRooted(scriptPath))
                    {
                        fullPath = Path.GetFullPath(scriptPath); // 将相对路径转换为绝对路径，但对已经是绝对路径的不做改变
                        filename = Path.GetFileName(scriptPath);
                    }
                    else
                    {
                        // 相对路径处理（这里假设启动目录为当前工作目录）
                        fullPath = Path.Combine(Directory.GetCurrentDirectory(), scriptPath);
                        filename = Path.GetFileName(scriptPath);
                    }
                    runWithPython = true;
                }
                else if (args.Length > 0)
                {
                    // 非 Python 可执行文件，获取其路径
                    string exePath = args[0];
                    fullPath = Path.GetFullPath(exePath);
                    if (!fullPath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) && !Path.HasExtension(fullPath))
                    {
                        fullPath += ".exe";
                    }

                    // 确保非Python可执行文件名有.exe后缀
                    filename = Path.GetFileName(exePath);
                    if (!filename.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) && !Path.HasExtension(filename))
                    {
                        filename += ".exe";
                    }
                    runWithPython = false;
                }
                else
                {
                    // 如果没有有效的命令，则设置为空
                    fullPath = "";
                    filename = "";
                    runWithPython = false;
                }
            }
        }
    }
}
