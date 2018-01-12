using StudyTimeHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTimeHelper.Service
{
    public interface IEventService
    {
        bool CreateEvent(EventCreate model);
        IEnumerable<EventListItem> GetEvents();
        EventDetail GetEventById(int eventId);
        bool UpdateEvent(EventEdit model);
        bool DeleteEvent(int eventId);
        
    }
}
