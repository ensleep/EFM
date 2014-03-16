using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;

namespace Es文件管理系统
{
    public partial class Form1 :Form
    {
        public List<FileInfo> listFile = new List<FileInfo>();
        public delegate void dgSetVisible(bool vis);
        public Form1()
        {
            InitializeComponent();
            //tvGate.Nodes.Add("start");

            //string[] args = System.Environment.GetCommandLineArgs();
            //string filePath = args[0];
            //for (int i = 0; i <= args.Length - 1; i++)
            //{
            //    tvGate.Nodes.Add(String.Join(", ", System.Environment.GetCommandLineArgs()));
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //axPdfShow.LoadFile("readMe.txt");
            axPdfShow.Hide();
            webBrowser1.Hide();
            loadGate();

        }
        public void loadGate()
        {
            if(Directory.Exists(Environment.CurrentDirectory + "\\文件列表\\"))
            {
                LoadFold(Environment.CurrentDirectory + "\\文件列表\\");
            }
            //try
            //{
            //    XmlDocument doc = new XmlDocument();
            //    doc.Load("1.xml");
            //    DirAndFiles daf = FileHelper.Xml2DirAndFiles(doc);
            //    tvGate.Nodes.Add(MakeGate(daf));

            //}catch(Exception ex)
            //{
            //    MessageBox.Show("未加载任何文件");
            //}
        }
        public TreeNode MakeGate(DirAndFiles daf)
        {
            TreeNode tn = new TreeNode();
            tn.Text = daf.Name;
            foreach(var d in daf.ChildDir)
            {
                tn.Nodes.Add(MakeGate(d));
                
            }
            foreach(var f in daf.listFileName)
            {
                tn.Nodes.Add(f);
            }
            return tn;
        }
        //private void listBox1_DoubleClick(object sender, EventArgs e)
        //{
        //    if (tvGate.SelectedItems.Count > 0)
        //    {
        //        string fileName = listBox1.SelectedItems[0].ToString();
        //        FileInfo fi = listFile.Where(m => m.Name == fileName).FirstOrDefault();
        //        axPdfShow.LoadFile(@"File\" + fi.Path);

        //    }
        //}

        private void 添加文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFile af = new AddFile(this);
            af.Show();
        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    listBox2.Items.Clear();
        //    string wantfile = textBox1.Text.Trim();
        //    foreach(var item in listFile.Where(m => m.Name.Contains(wantfile)))
        //    {
        //        listBox2.Items.Add(item.Name);
        //    }
        //}

        //private void listBox2_DoubleClick(object sender, EventArgs e)
        //{
        //    if (listBox2.SelectedItems.Count > 0)
        //    {
        //        string fileName = listBox2.SelectedItems[0].ToString();
        //        FileInfo fi = listFile.Where(m => m.Name == fileName).FirstOrDefault();
        //        axPdfShow.LoadFile(@"File\" + fi.Path);

        //    }
        //}

        //private void listBox1_Click(object sender, EventArgs e)
        //{
        //    if (listBox1.SelectedItems.Count > 0)
        //    {
        //        string fileName = listBox1.SelectedItems[0].ToString();
        //        FileInfo fi = listFile.Where(m => m.Name == fileName).FirstOrDefault();
        //        label1.Text = "文件ID:"+fi.Path+"     "+"添加时间:"+fi.AddDate;

        //    }

        //}

        //private void listBox2_Click(object sender, EventArgs e)
        //{
        //    if (listBox2.SelectedItems.Count > 0)
        //    {
        //        string fileName = listBox2.SelectedItems[0].ToString();
        //        FileInfo fi = listFile.Where(m => m.Name == fileName).FirstOrDefault();
        //        label1.Text = "文件ID:" + fi.Path + "     " + "添加时间:" + fi.AddDate;

        //    }
        //}

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode==Keys.Insert)
        //    {
        //        AddFile af = new AddFile(this);
        //        af.Show();
        //    }
        //}

        //private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if(tabControl1.SelectedIndex==0)
        //    {
        //        if(listBox1.SelectedItems.Count>0)
        //        {
        //            delXmlFile(listBox1.SelectedItems[0].ToString());
        //        }
        //    }
        //    else
        //    {
        //        if (listBox2.SelectedItems.Count > 0)
        //        {
        //            delXmlFile(listBox2.SelectedItems[0].ToString());
        //        }
        //    }
        //    loadGate();
        //}

        private void delXmlFile(string p)
        {
            try { 
                string filepath = listFile.Where(m => m.Name == p).FirstOrDefault().Path;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("File.xml");
                //XmlNode fileNode = xmlDoc.SelectNodes("//Files/File/@FilePath='" + filepath + "'")[0];
                XmlNode filesNode = xmlDoc.SelectNodes("//Files")[0];

                filesNode.RemoveChild(filesNode.SelectNodes("//File[@FilePath='" + filepath + "']")[0]);
                File.Delete(@"File\" + filepath);
                xmlDoc.Save("File.xml");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void 导出所有文件到文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            if(fbd.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    foreach(var m in listFile)
                    {
                        File.Copy(@"File\"+m.Path,fbd.SelectedPath+@"\"+m.Name+".pdf",true);
                    }
                    MessageBox.Show("导出成功！");
                    System.Diagnostics.Process.Start("explorer.exe", fbd.SelectedPath);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {

                }
            }
        }

        private void 打开文件目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void OpenEFM(string fileFull)
        {
        }
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpAbout ha = new HelpAbout();
            ha.Show();
        }
        public void SetVisible(bool vis)
        {
            if (this.InvokeRequired)
            {
                dgSetVisible dv = new dgSetVisible(SetVisible);
                this.Invoke(dv, vis);
            }
            else
            {
                if(vis)
                {
                    this.Show();
                }
                else
                {
                    this.Hide();
                }
            }
        }
        private void 文件夹转为efm文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "选择您要转换的文件夹，此文件夹的内容将作为您的一级目录";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "efm文件保存位置";
                sfd.AddExtension = true;
                sfd.DefaultExt = ".efm";
                if(sfd.ShowDialog()==DialogResult.OK)
                {
                    this.Hide();
                    TransForm tf = new TransForm(1, fbd.SelectedPath.ToString(), sfd.FileName.ToString().ToString(),this);
                    tf.Show();

                }
            }
            
        }

        private void 文件夹生成xmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog()==DialogResult.OK)
            {
                DirAndFiles daf = FileHelper.GetDirAndFiles(fbd.SelectedPath);
                FileHelper.DirAndFiles2Xml("1.xml",daf);
            }
        }

        private void 加载文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog()==DialogResult.OK)
            {
                LoadFold(fbd.SelectedPath);
            }
        }
        /// <summary>
        /// 将文件夹作为内容加载，生成目录
        /// </summary>
        /// <param name="path">文件夹目录</param>
        private void LoadFold(string path)
        {
            if(path.EndsWith("\\"))
            {
                path += "\\";
            }
            tvGate.Nodes.Clear();
            tvGate.Nodes.Add(SetDir2Cate(path));
        }
        private TreeNode SetDir2Cate(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            TreeNode tn = new TreeNode();
            tn.Text = di.Name;
            foreach(var d in di.GetDirectories())
            {
                tn.Nodes.Add(SetDir2Cate(d.FullName));
            }
            foreach(var f in di.GetFiles())
            {
                tn.Nodes.Add(f.FullName,f.Name);
            }
            return tn;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            { 
                string str = textBox1.Text.Trim();
                tvSearch.Nodes.Clear();
                TreeNode tn = tvGate.Nodes[0];
                GetSearch(tn,str);
            }
        }
        private void GetSearch(TreeNode tn,string str)
        {
            foreach(TreeNode n in tn.Nodes)
            {
                if(n.Nodes.Count<1)
                {
                    if(n.Text.IndexOf(str)>-1)
                    {
                        tvSearch.Nodes.Add(n.Name,n.Text);

                    }
                }
                else
                {
                    GetSearch(n,str);
                }
            }
        }
        private TreeNode RemoveNodes(TreeNode tn,string str)
        {
            foreach(TreeNode t in tn.Nodes)
            {
                if(t.Text.IndexOf(str)<1)
                {
                    tn.Nodes.Remove(t);
                }
                else
                {
                    TreeNode ntn =(TreeNode) t.Clone();
                    tn.Nodes[tn.Nodes.IndexOf(t)] = RemoveNodes(ntn, str);
                }
            }
            return tn;
        }

        private void 导入EFM文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.DefaultExt = "efm";
            if(opd.ShowDialog()==DialogResult.OK)
            {
                if (Directory.Exists(Environment.CurrentDirectory + "\\文件列表\\"))
                {
                    Directory.Delete(Environment.CurrentDirectory + "\\文件列表\\", true);
                }
                TransForm tf = new TransForm(1, opd.FileName, Environment.CurrentDirectory + "\\文件列表\\", this);
                this.Hide();
                tf.Show();
            }
        }

        private void tvGate_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void tvGate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (((TreeView)sender).SelectedNode != null && ((TreeView)sender).SelectedNode.Nodes.Count < 1)
            {
                TreeNode tn = ((TreeView)sender).SelectedNode;
                string ext = tn.Text.Split('.').Last<string>();
                if (".jpg.png.bmp.".IndexOf("." + ext + ".") > -1)
                {
                    webBrowser1.DocumentText = @"<html><head></head><body><img src='" + tn.Name + @"'/></body></html>";
                    axPdfShow.Hide();
                    webBrowser1.Show();
                }
                else if ("pdf" == ext)
                {
                    axPdfShow.LoadFile(tn.Name);
                    webBrowser1.Hide();
                    axPdfShow.Show();
                }
            }
        }

        private void tvSearch_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (((TreeView)sender).SelectedNode != null && ((TreeView)sender).SelectedNode.Nodes.Count < 1)
            {
                TreeNode tn = ((TreeView)sender).SelectedNode;
                string ext = tn.Text.Split('.').Last<string>();
                if (".jpg.png.bmp.".IndexOf("." + ext + ".") > -1)
                {
                    webBrowser1.DocumentText = @"<html><head></head><body><img src='" + tn.Name + @"'/></body></html>";
                    axPdfShow.Hide();
                    webBrowser1.Show();
                }
                else if ("pdf" == ext)
                {
                    axPdfShow.LoadFile(tn.Name);
                    webBrowser1.Hide();
                    axPdfShow.Show();
                }
            }
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
            {
                loadGate();
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for(i=0;i<s.Length;i++)
            {
                if(s[i].Trim()!=""&&File.Exists(s[i].Trim()))
                {
                    if(s[i].Split('.').Last<string>()=="efm")
                    {
                        if (Directory.Exists(Environment.CurrentDirectory + "\\文件列表\\"))
                        {
                            Directory.Delete(Environment.CurrentDirectory + "\\文件列表\\", true);
                        }
                        TransForm tf = new TransForm(1, s[i].Trim(), Environment.CurrentDirectory + "\\文件列表\\", this);
                        this.Hide();
                        tf.Show();
                        break;
                    }
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
    }
    public class FileInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime? AddDate { get; set; }
    }
}
