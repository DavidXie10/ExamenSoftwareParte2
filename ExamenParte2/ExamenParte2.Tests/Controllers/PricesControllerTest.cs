using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamenParte2.Controllers;
using System.Web.Mvc;

namespace ExamenParte2.Tests.Controllers {
    [TestClass]
    public class PricesControllerTest {
        [TestMethod]
        public void TestShowPricesViewResultNotNull() {
            PricesController pricesController = new PricesController();
            ActionResult view = pricesController.ShowPrices("");
            Assert.IsNotNull(view);
        }

        [TestMethod]
        public void TestShowPricesViewResult() {
            PricesController pricesController = new PricesController();
            ViewResult view = pricesController.ShowPrices("") as ViewResult;
            Assert.AreEqual("ShowPrices", view.ViewName);
        }

        [TestMethod]
        public void TestInvoiceViewResultNotNull() {
            PricesController pricesController = new PricesController();
            ActionResult view = pricesController.Invoice();
            Assert.IsNotNull(view);
        }

        [TestMethod]
        public void TestInvoiceViewResult() {
            PricesController pricesController = new PricesController();
            ViewResult view = pricesController.Invoice() as ViewResult;
            Assert.AreEqual("Invoice", view.ViewName);
        }

        [TestMethod]
        public void TestHeaderValueIsCorrect() {
            PricesController pricesController = new PricesController();
            ViewResult view = pricesController.ShowPrices("Su pizza personalizada") as ViewResult;
            Assert.AreEqual("Su pizza personalizada", view.ViewBag.Header);
        }
    }
}
