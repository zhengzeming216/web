using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.IService;

namespace ZSZ.AdminWeb.Controllers
{
    public class HomeController : Controller
    {
        public ICityService cityService { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            if (Session["aa"] != null)
            {
                return Content(Session["aa"].ToString());
            }
            else
            {
                Session["aa"] = "aaa";
            }
            cityService.Add("深圳");
            return Content("OK");
        }
    }
}