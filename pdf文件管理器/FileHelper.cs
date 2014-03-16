using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace Es文件管理系统
{
    public static class FileHelper
    {

        //调用windows API获取磁盘空闲空间
        //导入库
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern bool GetDiskFreeSpace([MarshalAs(UnmanagedType.LPTStr)]string rootPathName,
        ref int sectorsPerCluster, ref int bytesPerSector, ref int numberOfFreeClusters, ref int totalNumbeOfClusters);
        /// <summary>
        /// 获取指定路径的大小
        /// </summary>
        /// <param name="dirPath">路径</param>
        /// <returns></returns>
        public static long GetDirectoryLength(string dirPath)
        {
            long len = 0;
            //判断该路径是否存在（是否为文件夹）
            if (!Directory.Exists(dirPath))
            {
                //查询文件的大小
                len = FileSize(dirPath);
            }
            else
            {
                //定义一个DirectoryInfo对象
                DirectoryInfo di = new DirectoryInfo(dirPath);

                //通过GetFiles方法，获取di目录中的所有文件的大小
                foreach (System.IO.FileInfo fi in di.GetFiles())
                {
                    len += fi.Length;
                }
                //获取di中所有的文件夹，并存到一个新的对象数组中，以进行递归
                DirectoryInfo[] dis = di.GetDirectories();
                if (dis.Length > 0)
                {
                    for (int i = 0; i < dis.Length; i++)
                    {
                        len += GetDirectoryLength(dis[i].FullName);
                    }
                }
            }
            return len;
        }

        /// <summary>
        /// 获取指定路径的占用空间
        /// </summary>
        /// <param name="dirPath">路径</param>
        /// <returns></returns>
        public static long GetDirectorySpace(string dirPath)
        {
            //返回值
            long len = 0;
            //判断该路径是否存在（是否为文件夹）
            if (!Directory.Exists(dirPath))
            {
                //如果是文件，则调用
                len = FileSpace(dirPath);
            }
            else
            {
                //定义一个DirectoryInfo对象
                DirectoryInfo di = new DirectoryInfo(dirPath);
                //本机的簇值
                long clusterSize = GetClusterSize(di);
                //遍历目录下的文件，获取总占用空间
                foreach (System.IO.FileInfo fi in di.GetFiles())
                {
                    //文件大小除以簇，余若不为0
                    if (fi.Length % clusterSize != 0)
                    {
                        decimal res = fi.Length / clusterSize;
                        //文件大小除以簇，取整数加1。为该文件占用簇的值
                        int clu = Convert.ToInt32(Math.Ceiling(res)) + 1;
                        long result = clusterSize * clu;
                        len += result;
                    }
                    else
                    {
                        //余若为0，则占用空间等于文件大小
                        len += fi.Length;
                    }
                }
                //获取di中所有的文件夹，并存到一个新的对象数组中，以进行递归
                DirectoryInfo[] dis = di.GetDirectories();
                if (dis.Length > 0)
                {
                    for (int i = 0; i < dis.Length; i++)
                    {
                        len += GetDirectorySpace(dis[i].FullName);
                    }
                }
            }
            return len;
        }

        //所给路径中所对应的文件大小
        public static long FileSize(string filePath)
        {
            //定义一个System.IO.FileInfo对象，是指与filePath所指向的文件相关联，以获取其大小
            System.IO.FileInfo FileInfo = new System.IO.FileInfo(filePath);
            return FileInfo.Length;
        }

        //所给路径中所对应的文件占用空间
        public static long FileSpace(string filePath)
        {
            long temp = 0;
            //定义一个System.IO.FileInfo对象，是指与filePath所指向的文件相关联，以获取其大小
            System.IO.FileInfo FileInfo = new System.IO.FileInfo(filePath);
            long clusterSize = GetClusterSize(FileInfo);
            if (FileInfo.Length % clusterSize != 0)
            {
                decimal res =FileInfo.Length / clusterSize;
                int clu = Convert.ToInt32(Math.Ceiling(res)) + 1;
                temp = clusterSize * clu;
            }
            else
            {
                return FileInfo.Length;
            }
            return temp;
        }

        public static DiskInfo GetDiskInfo(string rootPathName)
        {
            DiskInfo diskInfo = new DiskInfo();
            int sectorsPerCluster = 0, bytesPerSector = 0, numberOfFreeClusters = 0, totalNumberOfClusters = 0;
            GetDiskFreeSpace(rootPathName, ref sectorsPerCluster, ref bytesPerSector, ref numberOfFreeClusters, ref totalNumberOfClusters);

            //每簇的扇区数
            diskInfo.SectorsPerCluster = sectorsPerCluster;
            //每扇区字节
            diskInfo.BytesPerSector = bytesPerSector;

            return diskInfo;
        }

        //// <summary>
        /// 结构。硬盘信息
        /// </summary>
        public struct DiskInfo
        {
            public string RootPathName;
            //每簇的扇区数
            public int SectorsPerCluster;
            //每扇区字节
            public int BytesPerSector;
            public int NumberOfFreeClusters;
            public int TotalNumberOfClusters;
        }
        /// <summary>
        /// 获取每簇的字节
        /// </summary>
        /// <param name="file">指定文件</param>
        /// <returns></returns>
        public static long GetClusterSize(System.IO.FileInfo file)
        {
            long clusterSize = 0;
            DiskInfo diskInfo = new DiskInfo();
            diskInfo = GetDiskInfo(file.Directory.Root.FullName);
            clusterSize = (diskInfo.BytesPerSector * diskInfo.SectorsPerCluster);
            return clusterSize;
        }

        /// <summary>
        /// 获取每簇的字节
        /// </summary>
        /// <param name="dir">指定目录</param>
        /// <returns></returns>
        public static long GetClusterSize(DirectoryInfo dir)
        {
            long clusterSize = 0;
            DiskInfo diskInfo = new DiskInfo();
            diskInfo = GetDiskInfo(dir.Root.FullName);
            clusterSize = (diskInfo.BytesPerSector * diskInfo.SectorsPerCluster);
            return clusterSize;
        }
        public static DirAndFiles GetDirAndFiles(string path)
        {
            if(path.EndsWith("\\")||path.EndsWith("//"))
            {
                path +="\\";
            }
            DirectoryInfo di = new DirectoryInfo(path);
            DirAndFiles daf = new DirAndFiles();
            daf.Name = di.Name;
            GetFilesAndDirs(ref daf, di);
            return daf;
        }
        private static void GetFilesAndDirs(ref DirAndFiles daf,DirectoryInfo di)
        {
            foreach(var f in di.GetFiles())
            {
                List<String> ls=daf.listFileName;
                ls.Add(f.Name);
                daf.listFileName = ls;
            }
            foreach(var d in di.GetDirectories())
            {
                DirAndFiles cdaf =new DirAndFiles();
                cdaf.Name=d.Name;
                GetFilesAndDirs(ref cdaf, d);
                List<DirAndFiles> ld = new List<DirAndFiles>();
                ld = daf.ChildDir;
                ld.Add(cdaf);
                daf.ChildDir = ld;
            }
        }
        public static void DirAndFiles2Xml(string path,DirAndFiles daf)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement xe = doc.CreateElement("Info");
            doc.AppendChild(xe);
            DirAndFiles2Doc(daf,ref xe,ref doc);
            doc.Save(path);
        }
        public static void DirAndFiles2Doc(DirAndFiles daf,ref XmlElement xxe,ref XmlDocument doc)
        {
            XmlElement xe = doc.CreateElement("dir");
            XmlAttribute attr = doc.CreateAttribute("name");
            attr.Value = daf.Name;
            xe.Attributes.Append(attr);
            xxe.AppendChild(xe);
            foreach (var f in daf.listFileName)
            {
                XmlElement xn = doc.CreateElement("file");
                XmlAttribute attr1 = doc.CreateAttribute("name");
                attr1.Value =f;
                xn.Attributes.Append(attr1);
                xe.AppendChild(xn);
            }
            foreach (var cdaf in daf.ChildDir)
            {
                DirAndFiles2Doc(cdaf, ref xe,ref doc);
            }
        }
        public static DirAndFiles Xml2DirAndFiles(XmlDocument doc)
        {
            DirAndFiles daf=new DirAndFiles();
            if(doc.ChildNodes[0].Name=="Info")
            {
                daf= Node2DirAndFiles(doc.ChildNodes[0]);
            }
            return daf;
        }
        public static DirAndFiles Node2DirAndFiles(XmlNode xn)
        {
            DirAndFiles daf = new DirAndFiles();
            if(xn.Name!="Info")
            {
                daf.Name = xn.Attributes["name"].Value;

            }
            else
            {
                daf.Name = "文件目录";
            }
            foreach(XmlNode cn in xn.ChildNodes)
            {
                if(cn.Name=="dir")
                {
                    DirAndFiles ddaf= Node2DirAndFiles(cn);
                    daf.ChildDir.Add(ddaf);
                }
                else if(cn.Name=="file")
                {
                    daf.listFileName.Add(cn.Attributes["name"].Value);
                }
            }
            return daf;
        }

    }
}
