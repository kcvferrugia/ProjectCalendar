using System.Collections.Generic;
using StudyTimeHelper.Models;

namespace StudyTimeHelper.Contracts
{
    public interface IEvent
    {
        bool CreateEvent(EventCreate model);
        bool UpdateEvent(EventEdit model);
        bool DeleteEvent(int id);
        EventDetail GetEventById(int eventid);
        IEnumerable<EventListItem> GetEvents();
       
    }
}
