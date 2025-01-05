using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace icns4win.lib
{
    internal class BackendConfig
    {
        // 默认配置
        private static readonly bool dftSupportRenameAsKeys = true;
        private static readonly string[] dftArgs = {
            "icnsutil.exe e {source} -o {export}",
            "-k"
            };

        // 基本配置类
        public class Config
        {
            public string? customArgs { get; set; }
            public bool supportRenameAsKeys { get; set; }
            public string? keyArgs { get; set; }
        }

        // 初始化
        public static Config? currentConfig;

        /// <summary>
        /// 初始化配置文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool InitConfig(string filePath)
        {
            string jsonString = "";

            // 如果配置文件不存在，则创建默认配置文件
            if (!Path.Exists(filePath))
            {
                Config defaultConfig = new Config
                {
                    customArgs = dftArgs[0],
                    supportRenameAsKeys = dftSupportRenameAsKeys,
                    keyArgs = dftArgs[1]
                };

                jsonString = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
                try
                {
                    File.WriteAllText(filePath, jsonString);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // 如果 jsonString 为空（即非创建默认配置），则从配置文件中读取
            if (jsonString != null)
            {
                try
                {
                    jsonString = File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // 解析配置文件
            try
            {
                currentConfig = JsonSerializer.Deserialize<Config>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 设置为默认配置
        /// </summary>
        /// <returns></returns>
        public static bool SetToDefaultConfig()
        {
            try
            {
                currentConfig.customArgs = dftArgs[0];
                currentConfig.keyArgs = dftArgs[1];
                currentConfig.supportRenameAsKeys = dftSupportRenameAsKeys;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool SaveConfig(string filePath)
        {
            string jsonString = JsonSerializer.Serialize(currentConfig, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            try
            {
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
