using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using StudyTimeHelper.Data;
using StudyTimeHelper.Models;
using StudyTimeHelper.Service;

namespace StudyTimeHelper.API.Controllers
{
  
    
        [Authorize]
        public class Ok : ApiController
        {
            // GET /note
            public IHttpActionResult GetAll()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var eventService = new EventService(userId);
                var events = eventService.GetEvents();
                return Ok(events);
            }
            //public IHttpActionResult Get(int id)
            //{
            //    EventService eventService = CreateEventService();
            //    var event = eventService.GetEventById(id);
            //    return Ok(event);
            //}

            public IHttpActionResult Post(EventCreate model)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var service = CreateEventService();

                if (!service.CreateEvent(model))
                    return InternalServerError();

                return Ok();
            }

            public IHttpActionResult Put(EventEdit model)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateEventService();

                if (!service.UpdateEvent(model))
                    return InternalServerError();

                return Ok();
            }

            public IHttpActionResult DeleteEvent(int id)
            {
                var service = CreateEventService();

                if (!service.DeleteEvent(id))
                    return InternalServerError();

                return Ok();
            }

            private EventService CreateEventService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var eventService = new EventService(userId);
                return eventService;
            }
        }
    
}
