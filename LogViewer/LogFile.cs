using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace LogViewer
{
    /// <summary>
    /// 日志文件
    /// </summary>
    public class LogFile
    {
        private string zipFilePath = null;

        /// <summary>
        /// 得到压缩包中的文件
        /// </summary>
        /// <param name="zipFilePath"></param>
        /// <returns></returns>
        public string[] GetFileNames(string zipFilePath)
        {
            if (!File.Exists(zipFilePath))
            {
                return null;
            }
            this.zipFilePath = zipFilePath;
            using (ZipFile zFile = new ZipFile(zipFilePath))
            {
                string[] files = new string[zFile.Count];
                int index = 0;
                foreach (ZipEntry e in zFile)
                {
                    if (e.IsFile)
                    {
                        files[index++] = e.Name;
                    }
                }
                return files;
            }
        }

        /// <summary>
        /// 得到文件的内容
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetFileContent(string fileName, Encoding encoding)
        {
            if (!File.Exists(zipFilePath))
            {
                return null;
            }
            using (ZipFile zFile = new ZipFile(zipFilePath))
            {
                foreach (ZipEntry e in zFile)
                {
                    if (fileName == e.Name)
                    {
                        Stream s = zFile.GetInputStream(e);
                        StreamReader reader = new StreamReader(s, encoding);
                        return reader.ReadToEnd().Replace("\n", "\r\n");
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 读取图片
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Image GetFileImage(string fileName)
        {
            if (!File.Exists(zipFilePath))
            {
                return null;
            }
            using (ZipFile zFile = new ZipFile(zipFilePath))
            {
                ZipEntry e = zFile.GetEntry(fileName);
                Stream s = zFile.GetInputStream(e);
                return Image.FromStream(s);
            }
        }

        /// <summary>
        /// 返回文件流
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Stream GetFileStream(string fileName)
        {
            if (!File.Exists(zipFilePath))
            {
                return null;
            }
            ZipFile zFile = new ZipFile(zipFilePath);
            ZipEntry e = zFile.GetEntry(fileName);
            return zFile.GetInputStream(e);
        }

        /// <summary>
        /// 判断文件名是否是图片
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public FileType GetFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            if (ext.EndsWith("png") || ext.EndsWith("jpg") || ext.EndsWith("bmp"))
            {
                return FileType.Image;
            }
            else if (ext.EndsWith("pcm"))
            {
                return FileType.PCM;
            }
            else
            {
                return FileType.Text;
            }
        }


    }
}
