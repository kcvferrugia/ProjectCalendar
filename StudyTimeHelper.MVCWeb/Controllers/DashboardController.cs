using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyTimeHelper.Data;

namespace StudyTimeHelper.MVCWeb.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Details()
        {
            throw new NotImplementedException();

        }


        [HttpPost]
        public JsonResult SaveEvent(Event e)
        {
            var status = false;
            using (StudyTimeHelperDbContext dc = new StudyTimeHelperDbContext())
            {
                if (e.EventId > 0)
                {
                    //Update the event
                    var v = dc.Events.Where(a => a.EventId == e.EventId).FirstOrDefault();
                    if (v != null)
                    {
                        v.Title = e.Title;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsAllDay = e.IsAllDay;
                        v.ThemeColor = e.ThemeColor;

                    }

                }
                else
                {
                    dc.Events.Add(e);
                }

                dc.SaveChanges();
                status = true;
            }

            return new JsonResult {Data = new { status }};
        }


        [HttpPost]
        public JsonResult DelteEvent(int eventId)
        {
            var status = false;
            using (StudyTimeHelperDbContext dc = new StudyTimeHelperDbContext())
            {
                var v = dc.Events.Where(a => a.EventId == eventId).FirstOrDefault();
                if (v != null)
                {
                    dc.Events.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
                return new JsonResult{Data = new {status}};

            }
        }
    };
}

