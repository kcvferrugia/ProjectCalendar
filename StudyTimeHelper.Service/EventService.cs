using System;
using System.Collections.Generic;
using System.Linq;
using StudyTimeHelper.Contracts;
using StudyTimeHelper.Data;
using StudyTimeHelper.Models;

namespace StudyTimeHelper.Service
{
    public class EventService : IEventService
    {
        private readonly Guid _studentId;

        public EventService(Guid studentId)
        {
            _studentId = studentId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Event()
                {
                    
                    Title = model.Title,
                    IsAllDay = model.IsAllDay,
                    Start = model.Start,
                    End = model.End,    
                    Description = model.Description,
                    ThemeColor = model.ThemeColor,
                    EventRepeat = model.EventRepeat,
                    
                };
            using (var ctx = new StudyTimeHelperDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new StudyTimeHelperDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    Title = e.Title,
                                    IsAllDay = e.IsAllDay,
                                    Start = e.Start,
                                    End = e.End,
                                    Description = e.Description,
                                    ThemeColor = e.ThemeColor,
                                    EventRepeat =e.EventRepeat,

                                });
                return query.ToArray();
            }
        }

        public EventDetail GetEventById(int id)
        {
            using (var ctx = new StudyTimeHelperDbContext())
            {
             var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == id && e.StudentId == _studentId);
                return
                    new EventDetail
                    {
                        EventId = entity.EventId,
                        Title = entity.Title,
                        IsAllDay= entity.IsAllDay,
                        Start = entity.Start,
                        End = entity.End,
                        Description = entity.Description,
                        ThemeColor = entity.ThemeColor,
                        EventRepeat = entity.EventRepeat,

                    };
            }
        }

        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new StudyTimeHelperDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == model.EventId);

                            entity.Title = model.Title;
                            entity.IsAllDay = model.IsAllDay;
                            entity.Start = model.Start;
                            entity.End = model.End;
                            entity.Description = model.Description;
                            entity.ThemeColor = model.ThemeColor;
                            entity.EventRepeat = model.EventRepeat;

                            return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEvent(int id)
        {
            using (var ctx = new StudyTimeHelperDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == id && e.StudentId == _studentId);

                ctx.Events.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
