using StudyTimeHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTimeHelper.MVCWeb.Controllers
{
    public class HomeController : Controller
    {
        private StudyTimeHelperDbContext mm = new StudyTimeHelperDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}