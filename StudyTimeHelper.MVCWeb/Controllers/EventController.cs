
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StudyTimeHelper.Data;
using StudyTimeHelper.Models;
using StudyTimeHelper.Service;

namespace StudyTimeHelper.MVCWeb.Controllers
{
           
    public class EventController : Controller
    {
        private readonly Lazy<IEventService> _eventService;

        public  StudyTimeHelperDbContext db = new StudyTimeHelperDbContext();

        public EventController()
        {
           
                _eventService = new Lazy<IEventService>(() =>
                 new EventService(Guid.Parse(User.Identity.GetUserId())));
           
        }

        // FOR TESTING
        public EventController(Lazy<IEventService> eventService)
        {
            _eventService = eventService;
        }

        private IEventService EventService => _eventService.Value;

        // GET: Event
        public ActionResult Index()
        {
            var model = _eventService.Value.GetEvents();

            return View(model);
        }


        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);


            if (EventService.CreateEvent(model))
            {
                TempData["SaveResult"] = "Your event was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Event could not be created");
            return View(model);
        }


        // GET: Event/Edit/5
        // GET: Event/Details/5
        public ActionResult DetailEvent(int eventId)
        {
           
            var model = _eventService.Value.GetEventById(eventId);

            return View(model);
        }


        public ActionResult EditEvent(int eventId)
        {
            var detail = _eventService.Value.GetEventById(eventId);
            var model =
                new EventEdit
                {
                    EventId = detail.EventId, 
                    Title = detail.Title,
                    Description = detail.Description,
                    Start = detail.Start,
                    End = detail.End,
                    IsAllDay = detail.IsAllDay
                };

            return View(model);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int eventId, EventEdit model)
        {
            //var std = StudyTimeHelperDbContext.Where(s => s.Student == studentId).FirstOrDefault();
            if (!ModelState.IsValid) return View(model);


            if (model.EventId != eventId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_eventService.Value.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your event was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Event not updated");
            return View(model);
        }

        // GET: Event/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int eventId)
        {
            _eventService.Value.GetEventById(eventId);

            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEvent(int eventId)
        {
            _eventService.Value.GetEventById(eventId);
            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //        db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
    