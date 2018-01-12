using Microsoft.AspNet.Identity;
using StudyTimeHelper.Contracts;
using StudyTimeHelper.Data;
using StudyTimeHelper.Models;
using StudyTimeHelper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyTimeHelper.MVCWeb.Controllers
{
    public class FullController : Controller
    {

        public ActionResult Dash()
        {
            return View();
        }

    }
}