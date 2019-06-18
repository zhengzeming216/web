using Autofac;
using CaptchaGen;
using CodeCarvings.Piczard;
using log4net;
using MyIBLL;
using MyBLLImpl;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Common;
using System.Reflection;
using System.Net;
using ZSZ.CommonMVC;
using ZSZ.Service;

namespace ZSZ.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestService test = new TestService();
            test.Test();
        }

        static void Main2(string[] args)
        {
            //string str = CommonHelper.GenerateCaptchaCode(5);
            //Console.WriteLine(str);

            //代码发邮件
            //using (MailMessage mailMessage = new MailMessage())
            //using (SmtpClient smtpClient = new SmtpClient("smtp.qq.com"))
            //{
            //    mailMessage.To.Add("923536859@qq.com");
            //    //mailMessage.To.Add(接收邮箱 2);
            //    mailMessage.Body = "这是邮箱邮件的正文，呵呵呵呵呵呵呵呵呵呵呵呵或或或或或或或或或或或或或，你好";
            //    mailMessage.From = new MailAddress("1355740794@qq.com");
            //    mailMessage.Subject = "title标题测试邮箱功能是否成功";
            //    smtpClient.Credentials = new System.Net.NetworkCredential("1355740794@qq.com", "mxarkrlxpijuhjjg");//如果启用了“客户端授权码”，要用授权码代替密码
            //    smtpClient.Send(mailMessage);
            //}

            //缩略图
            //ImageProcessingJob job = new ImageProcessingJob();
            //job.Filters.Add(new FixedResizeConstraint(200, 200));
            //job.SaveProcessedImageToFileSystem(@"E:\img\test1.png",@"E:\img\testsmall.png");

            //验证码
            //using (MemoryStream ms = ImageFactory.GenerateImage(CommonHelper.GenerateCaptchaCode(5), 80, 200, 40, 8))
            //using (FileStream fs = File.OpenWrite(@"E:\img\1.jpg"))
            //{
            //    ms.CopyTo(fs);
            //}

            //log4net.Config.XmlConfigurator.Configure();
            //ILog log = LogManager.GetLogger(typeof(Program));
            //log.Debug("手机已充满");
            //log.Warn("手机已超120%");
            //log.Error("手机爆没了");

            //IScheduler sched = new StdSchedulerFactory().GetScheduler();
            //JobDetailImpl jdBossReport = new JobDetailImpl("jdTest", typeof(TestJob));
            //IMutableTrigger triggerBossReport = CronScheduleBuilder.DailyAtHourAndMinute(14,29).Build();//每天 23:45 执行一次
            //triggerBossReport.Key = new TriggerKey("triggerTest");
            //sched.ScheduleJob(jdBossReport, triggerBossReport);
            //sched.Start();

            //ContainerBuilder builder = new ContainerBuilder();
            ////builder.RegisterType<UserBLL>().As<IUserBLL>();

            //builder.RegisterAssemblyTypes(Assembly.Load("MyBLLImpl")).AsImplementedInterfaces()
            //    .PropertiesAutowired().SingleInstance();

            //IContainer container = builder.Build();

            //IUserBLL bll = container.Resolve<IUserBLL>();
            //bll.Add("admin","123456");

            //IDogBLL dogBll = container.Resolve<IDogBLL>();
            //dogBll.Say();

            string username = "test11";
            string appKey = "eb4d6baf46781302af6123";
            string templateId = "1409";
            string code = "hh88az";
            string phoneNum = "12821118877";
            //string url = "http://sms.rupeng.cn/SendSms.ashx?userName="+Uri.EscapeDataString(username) + "&appKey=" 
            //    + Uri.EscapeDataString(appKey) + "&templateId=" + Uri.EscapeDataString(templateId) + "&code=" 
            //    + Uri.EscapeDataString(code) + "&phoneNum=" + Uri.EscapeDataString(phoneNum) + "";

            //WebClient wc = new WebClient();
            //wc.Encoding = Encoding.UTF8;

            //string result = wc.DownloadString(url);

            MySMSSender sender = new MySMSSender();
            sender.UserName = username;
            sender.AppKey = appKey;
            var result = sender.SendSMS(templateId, code, phoneNum);
            Console.WriteLine(result.Code+",,"+result.Msg);

            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
