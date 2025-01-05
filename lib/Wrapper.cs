using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenJpegDotNet.IO;

namespace icns4win.lib
{
    internal class Wrapper
    {
        private static string currentTempDir = "";

        // 处理icns文件
        // TODO: 需要Parser!
        public static bool ProcessIcns(string filePath, string exportPath, bool renameAsKeys)
        {
            Guid guid = Guid.NewGuid();
            currentTempDir = Path.Combine(exportPath, guid.ToString());
            string args = BackendConfig.currentConfig.customArgs.Replace("{source}", filePath).Replace("{export}", currentTempDir);
            System.Diagnostics.Process.Start(args);
            return true;
        }

        // 复制所需文件到对应目录
        public static bool CopyFileToDest(string destPath, bool savePng, bool saveJp2, bool saveRgb, bool saveArgb, bool savePlist, bool saveBin, bool convertJp2ToPng)
        {

            return true;
        }

        // 转换jp2为png
        private static bool ConvertJp2ToPng(string jp2FilePath, string pngFilePath)
        {
            try
            {
                byte[] image = File.ReadAllBytes(jp2FilePath);

                using (Reader reader = new Reader(image))
                {
                    bool result = reader.ReadHeader();
                    if (!result)
                    {
                        return true;
                    }

                    Bitmap bitmap = reader.ReadData() as Bitmap;
                    if (bitmap == null)
                    {
                        return true;
                    }

                    bitmap.Save(pngFilePath, System.Drawing.Imaging.ImageFormat.Png);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // 清除文件
        public static bool ClearFiles()
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
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return true;
        }
    }
}
