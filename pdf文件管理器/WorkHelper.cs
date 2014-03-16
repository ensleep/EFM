using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Es文件管理系统
{
    public partial class WorkHelper : Form
    {
        public WorkHelper()
        {
            InitializeComponent();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

            listBoxShow.Items.Add(new ClockEveryDay() { time = DateTime.Now.AddHours(2), Content = "我我我我我我我我我我我我我我我" }.ToItem());
        }
    }
}
