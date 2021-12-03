using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamenParte2.Controllers;
using System.Web.Mvc;

namespace ExamenParte2.Tests.Controllers {
    [TestClass]
    public class PickUpOrderControllerTest {
        [TestMethod]
        public void TestInRestaurantViewResultNotNull() {
            PickUpOrderController pickUpController = new PickUpOrderController();
            ActionResult view = pickUpController.InRestaurant();
            Assert.IsNotNull(view);
        }

        [TestMethod]
        public void TestInRestaurantViewResult() {
            PickUpOrderController pickUpController = new PickUpOrderController();
            ViewResult view = pickUpController.InRestaurant() as ViewResult;
            Assert.AreEqual("Restaurant", view.ViewName);
        }

        [TestMethod]
        public void TestExpressViewResultNotNull() {
            PickUpOrderController pickUpController = new PickUpOrderController();
            ActionResult view = pickUpController.Express();
            Assert.IsNotNull(view);
        }

        [TestMethod]
        public void TestExpressViewResult() {
            PickUpOrderController pickUpController = new PickUpOrderController();
            ViewResult view = pickUpController.Express() as ViewResult;
            Assert.AreEqual("Express", view.ViewName);
        }
    }
}
