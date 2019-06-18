using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ZSZ.CommonMVC
{
    public class MySMSSender
    {
        public string UserName { get; set; }
        public string AppKey { get; set; }
        public MySMSResult SendSMS(string templateId, string code, string phoneNum)
        {
            string url = "http://sms.rupeng.cn/SendSms.ashx?userName=" + Uri.EscapeDataString(UserName) + "&appKey="
                + Uri.EscapeDataString(AppKey) + "&templateId=" + Uri.EscapeDataString(templateId) + "&code="
                + Uri.EscapeDataString(code) + "&phoneNum=" + Uri.EscapeDataString(phoneNum) + "";

            Console.WriteLine("tes11");
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            string resp = wc.DownloadString(url);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            MySMSResult result = jss.Deserialize<MySMSResult>(resp);
            return result;
        }
    }
}
