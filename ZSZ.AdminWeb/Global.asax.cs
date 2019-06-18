using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZSZ.AdminWeb.App_Start;
using ZSZ.IService;

namespace ZSZ.AdminWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();//启动日志

            GlobalFilters.Filters.Add(new ZSZExceptionFilter());//AOP过滤器——异常

            //IOC控制反转
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();//把当前程序集中的Controller都注册
            Assembly asm = Assembly.Load("ZSZ.Service");
            builder.RegisterAssemblyTypes(asm).Where(t => !t.IsAbstract && typeof(IServiceSupport).IsAssignableFrom(t))
                .AsImplementedInterfaces().PropertiesAutowired();
            //type1.IsAssignableFrom（type2）type1类型的变量是否可以指向type2类型的对象
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
