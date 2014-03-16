using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Es文件管理系统
{
    public class ClockEveryDay
    {
        public ClockEveryDay()
        {
            time = new DateTime();
            Content = "";
        }
        public DateTime time { get; set; }
        public string Content { get; set; }
        public string ToItem()
        {
            StringBuilder sb = new StringBuilder();
            TimeSpan ts=time-DateTime.Now;
            sb.Append("距离现在还有："+ts.Hours+"小时"+ts.Minutes+"分钟"+ts.Seconds+"秒\n");
            sb.Append("所定时间：" + time.ToString("hh:mm:ss")+"\n");
            sb.Append(Content);
            return sb.ToString();
        }
    }
}
