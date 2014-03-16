namespace Es文件管理系统
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tvGate = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tvSearch = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出所有文件到文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入EFM文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件夹转为efm文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件夹生成xmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.axPdfShow = new AxAcroPDFLib.AxAcroPDF();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPdfShow)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(191, 340);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tvGate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(183, 314);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "目录";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tvGate
            // 
            this.tvGate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvGate.Location = new System.Drawing.Point(3, 3);
            this.tvGate.Name = "tvGate";
            this.tvGate.Size = new System.Drawing.Size(177, 308);
            this.tvGate.TabIndex = 0;
            this.tvGate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvGate_AfterSelect);
            this.tvGate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvGate_MouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tvSearch);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(183, 314);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "搜索";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tvSearch
            // 
            this.tvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvSearch.Location = new System.Drawing.Point(3, 34);
            this.tvSearch.Name = "tvSearch";
            this.tvSearch.Size = new System.Drawing.Size(177, 277);
            this.tvSearch.TabIndex = 1;
            this.tvSearch.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSearch_AfterSelect);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(7, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.管理ToolStripMenuItem,
            this.删除文件ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.转换ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(12, 6);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(184, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 管理ToolStripMenuItem
            // 
            this.管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加文件ToolStripMenuItem,
            this.导出所有文件到文件夹ToolStripMenuItem,
            this.加载文件夹ToolStripMenuItem,
            this.导入EFM文件ToolStripMenuItem});
            this.管理ToolStripMenuItem.Name = "管理ToolStripMenuItem";
            this.管理ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.管理ToolStripMenuItem.Text = "文件";
            // 
            // 添加文件ToolStripMenuItem
            // 
            this.添加文件ToolStripMenuItem.Enabled = false;
            this.添加文件ToolStripMenuItem.Name = "添加文件ToolStripMenuItem";
            this.添加文件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.添加文件ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.添加文件ToolStripMenuItem.Text = "添加文件";
            this.添加文件ToolStripMenuItem.Click += new System.EventHandler(this.添加文件ToolStripMenuItem_Click);
            // 
            // 导出所有文件到文件夹ToolStripMenuItem
            // 
            this.导出所有文件到文件夹ToolStripMenuItem.Enabled = false;
            this.导出所有文件到文件夹ToolStripMenuItem.Name = "导出所有文件到文件夹ToolStripMenuItem";
            this.导出所有文件到文件夹ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.导出所有文件到文件夹ToolStripMenuItem.Text = "导出所有文件到文件夹";
            this.导出所有文件到文件夹ToolStripMenuItem.Click += new System.EventHandler(this.导出所有文件到文件夹ToolStripMenuItem_Click);
            // 
            // 加载文件夹ToolStripMenuItem
            // 
            this.加载文件夹ToolStripMenuItem.Enabled = false;
            this.加载文件夹ToolStripMenuItem.Name = "加载文件夹ToolStripMenuItem";
            this.加载文件夹ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.加载文件夹ToolStripMenuItem.Text = "加载文件夹";
            this.加载文件夹ToolStripMenuItem.Click += new System.EventHandler(this.加载文件夹ToolStripMenuItem_Click);
            // 
            // 导入EFM文件ToolStripMenuItem
            // 
            this.导入EFM文件ToolStripMenuItem.Name = "导入EFM文件ToolStripMenuItem";
            this.导入EFM文件ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.导入EFM文件ToolStripMenuItem.Text = "导入EFM文件";
            this.导入EFM文件ToolStripMenuItem.Click += new System.EventHandler(this.导入EFM文件ToolStripMenuItem_Click);
            // 
            // 删除文件ToolStripMenuItem
            // 
            this.删除文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.删除文件ToolStripMenuItem.Enabled = false;
            this.删除文件ToolStripMenuItem.Name = "删除文件ToolStripMenuItem";
            this.删除文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.删除文件ToolStripMenuItem.Text = "编辑";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 转换ToolStripMenuItem
            // 
            this.转换ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件夹转为efm文件ToolStripMenuItem,
            this.文件夹生成xmlToolStripMenuItem});
            this.转换ToolStripMenuItem.Name = "转换ToolStripMenuItem";
            this.转换ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.转换ToolStripMenuItem.Text = "转换";
            // 
            // 文件夹转为efm文件ToolStripMenuItem
            // 
            this.文件夹转为efm文件ToolStripMenuItem.Name = "文件夹转为efm文件ToolStripMenuItem";
            this.文件夹转为efm文件ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.文件夹转为efm文件ToolStripMenuItem.Text = "文件夹转为efm文件";
            this.文件夹转为efm文件ToolStripMenuItem.Click += new System.EventHandler(this.文件夹转为efm文件ToolStripMenuItem_Click);
            // 
            // 文件夹生成xmlToolStripMenuItem
            // 
            this.文件夹生成xmlToolStripMenuItem.Enabled = false;
            this.文件夹生成xmlToolStripMenuItem.Name = "文件夹生成xmlToolStripMenuItem";
            this.文件夹生成xmlToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.文件夹生成xmlToolStripMenuItem.Text = "文件夹生成xml";
            this.文件夹生成xmlToolStripMenuItem.Click += new System.EventHandler(this.文件夹生成xmlToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 4;
            // 
            // axPdfShow
            // 
            this.axPdfShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axPdfShow.Enabled = true;
            this.axPdfShow.Location = new System.Drawing.Point(205, 56);
            this.axPdfShow.Name = "axPdfShow";
            this.axPdfShow.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPdfShow.OcxState")));
            this.axPdfShow.Size = new System.Drawing.Size(614, 314);
            this.axPdfShow.TabIndex = 2;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(205, 56);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(625, 314);
            this.webBrowser1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(831, 372);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.axPdfShow);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "档案文件管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPdfShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private AxAcroPDFLib.AxAcroPDF axPdfShow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 导出所有文件到文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件夹转为efm文件ToolStripMenuItem;
        private System.Windows.Forms.TreeView tvGate;
        private System.Windows.Forms.TreeView tvSearch;
        private System.Windows.Forms.ToolStripMenuItem 文件夹生成xmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入EFM文件ToolStripMenuItem;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

