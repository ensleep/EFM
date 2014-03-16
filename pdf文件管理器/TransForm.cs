using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.BZip2;//要添加对ICSharpCode.SharpZipLib.dll的引用
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip;
using System.Threading;
using ICSharpCode.SharpZipLib.Checksums;

namespace Es文件管理系统
{
    public partial class TransForm : Form
    {
        delegate void dgSetLabel(string str);
        delegate void dgSetValue(int value);
        long dirSize;
        long zipSize;
        long nowSize = 0;
        bool over = false;
        public Form1 frm1;
        /// <summary>
        /// 转换窗口
        /// </summary>
        /// <param name="type">0：压缩，转成efm文件，1：转成文件夹</param>
        /// <param name="from">源文件夹或文件</param>
        /// <param name="fileFull">目标文件或文件夹</param>
        /// <param name="frm">引用窗体</param>
        public TransForm(int type, string from, string fileFull,Form1 frm)
        {
            InitializeComponent();
            progressBar1.Value = 0;
            frm1 = frm;
            lbl1.Text = "准备中....";
            Thread th = new Thread(TransThread);
            th.Start(new TransThreadPara { type=type,dirPath=from,zipFilePath=fileFull});
        }
        public void SetLabel(string str)
        {
            if(this.lbl1.InvokeRequired)
            {
                dgSetLabel ds = new dgSetLabel(SetLabel);
                this.lbl1.Invoke(ds, str);
            }
            else
            {
                lbl1.Text = str;
            }
        }
        public void SetValue(int value)
        {
            if (this.progressBar1.InvokeRequired)
            {
                dgSetValue dv = new dgSetValue(SetValue);
                this.progressBar1.Invoke(dv, value);
            }
            else
            {
                progressBar1.Value = value;
            }
        }
        public void TransThread(object obj)
        {
            if((obj as TransThreadPara).type==0)
            {
                string dirPath = (obj as TransThreadPara).dirPath;
                string zipFilePath = (obj as TransThreadPara).zipFilePath;
                ZipFileDirectory(dirPath, zipFilePath);
                over = true;
            }else if((obj as TransThreadPara).type==1)
            {
                string err="";
                string zipFilePath = (obj as TransThreadPara).dirPath;
                string unZipDir = (obj as TransThreadPara).zipFilePath;

                if (zipFilePath == string.Empty)
                {
                    err = "压缩文件不能为空！";
                }
                if (!File.Exists(zipFilePath))
                {
                    err = "压缩文件不存在！";
                }
                SetLabel("正在计算文件总大小");
                SetValue(3);
                zipSize = FileHelper.FileSize(zipFilePath);
                SetLabel("开始导入");
                SetValue(5);
                nowSize = 0;
                //解压文件夹为空时默认与压缩文件同一级目录下，跟压缩文件同名的文件夹
                if (unZipDir == string.Empty)
                    unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
                if (!unZipDir.EndsWith("//"))
                    unZipDir += "//";
                if (!Directory.Exists(unZipDir))
                    Directory.CreateDirectory(unZipDir);

                try
                {
                    using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
                    {

                        ZipEntry theEntry;
                        while ((theEntry = s.GetNextEntry()) != null)
                        {
                            string directoryName = Path.GetDirectoryName(theEntry.Name);
                            string fileName = Path.GetFileName(theEntry.Name);
                            if (directoryName.Length > 0)
                            {
                                Directory.CreateDirectory(unZipDir + directoryName);
                            }
                            if (!directoryName.EndsWith("//"))
                                directoryName += "//";
                            if (fileName != String.Empty)
                            {
                                using (FileStream streamWriter = File.Create(unZipDir + theEntry.Name))
                                {

                                    int size = 2048;
                                    byte[] data = new byte[2048];
                                    while (true)
                                    {
                                        size = s.Read(data, 0, data.Length);
                                        if (size > 0)
                                        {
                                            streamWriter.Write(data, 0, size);
                                            nowSize += size;
                                            if (zipSize-nowSize > 1)
                                            {
                                                nowSize += 2048;
                                                SetValue((int)(nowSize / zipSize * 95));
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }//while

                    }
                    over = true;
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
                if(err.Trim()!="")
                {
                    MessageBox.Show(err);
                }
            }
        }
        public void t(object obj)
        {
            string err;
            string dirPath = (obj as TransThreadPara).dirPath;
            string zipFilePath = (obj as TransThreadPara).zipFilePath;
            Zip.ZipFile(dirPath, zipFilePath, out err);
            err = "";
            if (dirPath == string.Empty)
            {
                err = "要压缩的文件夹不能为空！";
                throw new Exception(err);
            }
            if (!Directory.Exists(dirPath))
            {
                err = "要压缩的文件夹不存在！";
                throw new Exception(err);
            }
            //压缩文件名为空时使用文件夹名＋.zip
            if (zipFilePath == string.Empty)
            {
                if (dirPath.EndsWith("//"))
                {
                    dirPath = dirPath.Substring(0, dirPath.Length - 1);
                }
                zipFilePath = dirPath + ".zip";
            }

            try
            {
                string[] filenames = Directory.GetFileSystemEntries(dirPath);
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                SetLabel("正在计算文件总大小");
                SetValue(3);
                long dirSize = FileHelper.GetDirectoryLength(dirPath);
                long nowSize=0;
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePath)))
                {
                    SetLabel("开始压缩");
                    SetValue(5);
                    s.SetLevel(9);
                    byte[] buffer = new byte[4096];
                    foreach (string file in filenames)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                        nowSize+=4096;
                        SetValue((int)(nowSize / dirSize * 95));
                    }
                    SetValue(100);
                    s.Finish();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                throw new Exception(err);
            }
        }/// <summary>
        /// 压缩单个文件
        /// </summary>
        /// <param name="fileToZip">要压缩的文件</param>
        /// <param name="zipedFile">压缩后的文件</param>
        /// <param name="compressionLevel">压缩等级</param>
        /// <param name="blockSize">每次写入大小</param>
        public void ZipFile(string fileToZip, string zipedFile, int compressionLevel, int blockSize)
        {
            //如果文件没有找到，则报错
            if (!System.IO.File.Exists(fileToZip))
            {
                throw new System.IO.FileNotFoundException("指定要压缩的文件: " + fileToZip + " 不存在!");
            }

            using (System.IO.FileStream ZipFile = System.IO.File.Create(zipedFile))
            {
                using (ZipOutputStream ZipStream = new ZipOutputStream(ZipFile))
                {
                    using (System.IO.FileStream StreamToZip = new System.IO.FileStream(fileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        string fileName = fileToZip.Substring(fileToZip.LastIndexOf("\\") + 1);

                        ZipEntry ZipEntry = new ZipEntry(fileName);

                        ZipStream.PutNextEntry(ZipEntry);

                        ZipStream.SetLevel(compressionLevel);

                        byte[] buffer = new byte[blockSize];

                        int sizeRead = 0;

                        try
                        {
                            do
                            {
                                sizeRead = StreamToZip.Read(buffer, 0, buffer.Length);
                                ZipStream.Write(buffer, 0, sizeRead);
                            }
                            while (sizeRead > 0);
                        }
                        catch (System.Exception ex)
                        {
                            throw ex;
                        }

                        StreamToZip.Close();
                    }

                    ZipStream.Finish();
                    ZipStream.Close();
                }

                ZipFile.Close();
            }
        }

        /// <summary>
        /// 压缩单个文件
        /// </summary>
        /// <param name="fileToZip">要进行压缩的文件名</param>
        /// <param name="zipedFile">压缩后生成的压缩文件名</param>
        public void ZipFile(string fileToZip, string zipedFile)
        {
            //如果文件没有找到，则报错
            if (!File.Exists(fileToZip))
            {
                throw new System.IO.FileNotFoundException("指定要压缩的文件: " + fileToZip + " 不存在!");
            }

            using (FileStream fs = File.OpenRead(fileToZip))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                using (FileStream ZipFile = File.Create(zipedFile))
                {
                    using (ZipOutputStream ZipStream = new ZipOutputStream(ZipFile))
                    {
                        string fileName = fileToZip.Substring(fileToZip.LastIndexOf("\\") + 1);
                        ZipEntry ZipEntry = new ZipEntry(fileName);
                        ZipStream.PutNextEntry(ZipEntry);
                        ZipStream.SetLevel(5);

                        ZipStream.Write(buffer, 0, buffer.Length);
                        ZipStream.Finish();
                        ZipStream.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 压缩多层目录
        /// </summary>
        /// <param name="strDirectory">The directory.</param>
        /// <param name="zipedFile">The ziped file.</param>
        public void ZipFileDirectory(string strDirectory, string zipedFile)
        {
            using (System.IO.FileStream ZipFile = System.IO.File.Create(zipedFile))
            {
                SetLabel("正在计算文件总大小");
                SetValue(3);
                dirSize = FileHelper.GetDirectoryLength(strDirectory);
                SetLabel("开始压缩");
                SetValue(5);
                nowSize = 0;
                using (ZipOutputStream s = new ZipOutputStream(ZipFile))
                {
                    ZipSetp(strDirectory, s, "");
                    SetValue(100);
                }
                frm1.SetVisible(true);
            }
        }

        /// <summary>
        /// 递归遍历目录
        /// </summary>
        /// <param name="strDirectory">The directory.</param>
        /// <param name="s">The ZipOutputStream Object.</param>
        /// <param name="parentPath">The parent path.</param>
        public void ZipSetp(string strDirectory, ZipOutputStream s, string parentPath)
        {
            if (strDirectory[strDirectory.Length - 1] != Path.DirectorySeparatorChar)
            {
                strDirectory += Path.DirectorySeparatorChar;
            }
            Crc32 crc = new Crc32();

            string[] filenames = Directory.GetFileSystemEntries(strDirectory);

            foreach (string file in filenames)// 遍历所有的文件和目录
            {

                if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                {
                    string pPath = parentPath;
                    pPath += file.Substring(file.LastIndexOf("\\") + 1);
                    pPath += "\\";
                    ZipSetp(file, s, pPath);
                }

                else // 否则直接压缩文件
                {
                    //打开压缩文件
                    using (FileStream fs = File.OpenRead(file))
                    {

                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);

                        string fileName = parentPath + file.Substring(file.LastIndexOf("\\") + 1);
                        ZipEntry entry = new ZipEntry(fileName);

                        entry.DateTime = DateTime.Now;
                        entry.Size = fs.Length;

                        fs.Close();

                        crc.Reset();
                        crc.Update(buffer);

                        entry.Crc = crc.Value;
                        s.PutNextEntry(entry);

                        s.Write(buffer, 0, buffer.Length);
                        nowSize += buffer.Length;
                        SetValue((int)(nowSize / dirSize * 95));
                    }
                }
            }
        }

        /// <summary>
        /// 解压缩一个 zip 文件。
        /// </summary>
        /// <param name="zipedFile">The ziped file.</param>
        /// <param name="strDirectory">The STR directory.</param>
        /// <param name="password">zip 文件的密码。</param>
        /// <param name="overWrite">是否覆盖已存在的文件。</param>
        public void UnZip(string zipedFile, string strDirectory, string password, bool overWrite)
        {

            if (strDirectory == "")
                strDirectory = Directory.GetCurrentDirectory();
            if (!strDirectory.EndsWith("\\"))
                strDirectory = strDirectory + "\\";

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipedFile)))
            {
                s.Password = password;
                ZipEntry theEntry;

                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = "";
                    string pathToZip = "";
                    pathToZip = theEntry.Name;

                    if (pathToZip != "")
                        directoryName = Path.GetDirectoryName(pathToZip) + "\\";

                    string fileName = Path.GetFileName(pathToZip);

                    Directory.CreateDirectory(strDirectory + directoryName);

                    if (fileName != "")
                    {
                        if ((File.Exists(strDirectory + directoryName + fileName) && overWrite) || (!File.Exists(strDirectory + directoryName + fileName)))
                        {
                            using (FileStream streamWriter = File.Create(strDirectory + directoryName + fileName))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);

                                    if (size > 0)
                                        streamWriter.Write(data, 0, size);
                                    else
                                        break;
                                }
                                streamWriter.Close();
                            }
                        }
                    }
                }

                s.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(over)
            {
                frm1.Show();
                this.Dispose();
            }
        }

    }
    public class TransThreadPara
    {
        public int type { get; set; }
        public string dirPath{get;set;}
        public string zipFilePath { get; set; }
    }
}
