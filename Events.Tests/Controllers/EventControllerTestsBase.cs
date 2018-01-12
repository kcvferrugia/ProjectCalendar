using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyTimeHelper.MVCWeb.Controllers;
using StudyTimeHelper.Contracts;
using System;

namespace STHTests.Tests.Controllers
{
    [TestClass]
    public abstract class EventControllerTestsBase
    {

        protected EventController Controller;
        protected FakeEventService EventService;

       
        [TestInitialize]
        public virtual void Arrange()
        {
            EventService = new FakeEventService();
            EventController Controller = (new EventController(new Lazy<IEventService>(() => EventService)));
        }


    }

    internal class EventCreateController
    {
    }
}