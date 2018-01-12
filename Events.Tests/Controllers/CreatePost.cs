using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyTimeHelper.Models;

namespace Events.Tests.Controllers
{
    [TestClass]
    public class CreatePost : STHTests.Tests.Controllers.EventControllerTestsBase
    {
                
        private EventCreate _model;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            EventService.CreateEventReturnValue = true;
        }

        private ActionResult Act()
        {

            return Controller.Create(_model);
        }

        [TestMethod]
        public void ShouldReturnRedirectToRouteResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void ShouldSetSaveResult()
        {
            Act();

            Assert.AreEqual("Your event was created.", Controller.TempData["SaveResult"]);
        }
    }
}