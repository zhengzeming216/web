using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestIService;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IUserService user { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            bool result = user.CheckLogin("a", "b");
            return Content(result.ToString());
        }

        public ActionResult JsonHtml()
        {
            return View();
        }

        public ActionResult JsonData()
        {
            Person p = new Person() { Name="张三", Time=DateTime.Now };
            return Json(p);
            //return new JsonNetResult() { Data=p };
        }

    }
}