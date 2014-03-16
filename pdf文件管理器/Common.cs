using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Es文件管理系统
{
    public static class Common
    {
        public static void RegFile(string[] args)
        {//设置文件关联
            string keyName;
            string keyValue;
            keyName = "Es文件管理系统";
            keyValue = "Es文件管理系统";
            RegistryKey isExCommand = null;
            bool isCreateRegistry = true;
            try
            {
                //检查文件关联是否创建
                isExCommand = Registry.ClassesRoot.OpenSubKey(keyName);
                if (isExCommand == null)
                {
                    isCreateRegistry = true;
                }
                else
                {
                    if (isExCommand.GetValue("Create").ToString() == Application.ExecutablePath.ToString())
                    {
                        isCreateRegistry = false;
                    }
                    else
                    {
                        Registry.ClassesRoot.DeleteSubKeyTree(keyName);
                        isCreateRegistry = true;
                    }
                }
            }
            catch (Exception)
            {
                isCreateRegistry = true;
            }
            // 假如 文件关联 还没有创建，或是关联位置已被改变 
            if (isCreateRegistry)
            {
                try
                {
                    RegistryKey key, keyico;
                    key = Registry.ClassesRoot.CreateSubKey(keyName);
                    key.SetValue("Create", Application.ExecutablePath.ToString());
                    keyico = key.CreateSubKey("DefaultIcon");
                    keyico.SetValue("", Application.ExecutablePath + ",0");
                    key.SetValue("", keyValue);
                    key = key.CreateSubKey("Shell");
                    key = key.CreateSubKey("Open");
                    key = key.CreateSubKey("Command");
                    // 关联的位置 
                    key.SetValue("", "\"" + Application.ExecutablePath.ToString() + "\" \"%1\"");
                    // 关联的文件扩展名
                    keyName = ".efm";
                    keyValue = "Es文件管理系统";
                    key = Registry.ClassesRoot.CreateSubKey(keyName);
                    key.SetValue("", keyValue);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
