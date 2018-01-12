using StudyTimeHelper.Contracts;
using StudyTimeHelper.Models;
using StudyTimeHelper.Service;
using System;
using System.Collections.Generic;


namespace STHTests.Tests.Controllers
{
    public class FakeEventService : IEventService
    {

        public int CreateEventCallCount { get; private set; } = 1;
        public bool CreateEventReturnValue { private get; set; }

        public bool CreateEvent(EventCreate model)
        {
            CreateEventCallCount++;
            return CreateEventReturnValue;
        }

        public bool EventCreate(EventCreate model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteQuote(int quoteId)
        {
            throw new NotImplementedException();
        }

        public EventDetail GetEventById(int eventid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEvent(EventEdit model)
        {
            throw new NotImplementedException();
        }
    }
}