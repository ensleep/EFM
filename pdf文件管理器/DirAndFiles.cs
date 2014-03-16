using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Es文件管理系统
{
    public class DirAndFiles
    {
        public DirAndFiles()
        {
            ChildDir = new List<DirAndFiles>();
            listFileName = new List<String>();
        }
        public string Name { get; set; }
        public List<DirAndFiles> ChildDir { get; set; }
        public List<String> listFileName { get; set; }
    }
}
