using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenJpegDotNet;

namespace icns4win
{
    internal class Wrapper
    {
        private static string currentTempDir = "";

        // 处理icns文件
        public bool processIcns(string filePath, string exportPath, bool renameAsKeys)
        {
            Guid guid = Guid.NewGuid();
            currentTempDir = Path.Combine(exportPath, guid.ToString());
            string args = BackendConfig.currentConfig.customArgs.Replace("{source}", filePath).Replace("{export}", currentTempDir);
            System.Diagnostics.Process.Start(args);
            return true;
        }

        // 复制所需文件到对应目录
        public bool copyFileToDest(string destPath, bool savePng, bool saveJp2, bool saveRgb, bool saveArgb, bool savePlist, bool saveBin, bool convertJp2ToPng)
        {

            return true;
        }

        // 转换jp2为png
        private bool convertJp2ToPng(string jp2FilePath, string pngFilePath)
        {

            return true;
        }

        // 清除文件
        public bool clearFiles()
        {
            try
            {
                if (File.Exists(currentTempDir))
                {
                    Directory.Delete(currentTempDir, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                currentTempDir = "";
            }
            return true;
        }
    }
}
