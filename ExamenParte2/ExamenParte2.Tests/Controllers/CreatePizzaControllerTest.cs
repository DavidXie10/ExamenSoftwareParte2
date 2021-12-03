using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ExamenParte2.Controllers;
using ExamenParte2.Models;
using System.Collections.Generic;

namespace ExamenParte2.Tests.Controllers {
    [TestClass]
    public class CreatePizzaControllerTest {
        [TestMethod]
        public void TestCreatePizzaViewResultNotNull() {
            CreatePizzaController createPizzaController = new CreatePizzaController();
            ActionResult view = createPizzaController.CreatePizza();
            Assert.IsNotNull(view);
        }

        [TestMethod]
        public void TestCreatePizzaViewResult() {
            CreatePizzaController createPizzaController = new CreatePizzaController();
            ViewResult view = createPizzaController.CreatePizza() as ViewResult;
            Assert.AreEqual("CreatePizza", view.ViewName);
        }

        [TestMethod]
        public void TestAddPizzaSelectionAllValuesCountCorrect() {
            CreatePizzaController createPizzaController = new CreatePizzaController();
            PersonalizedPizza personalizedPizza = new PersonalizedPizza();
            personalizedPizza.Mass = "Original";
            personalizedPizza.Mozzarella = "Queso mozzarella";
            personalizedPizza.Sauce = "Salsa de tomate";
            personalizedPizza.Size = "Mediana";

            List<SelectedItem> products = new List<SelectedItem>();
            createPizzaController.AddPizzaSelection(products, personalizedPizza);
            Assert.AreEqual(4, products.Count);
        }
    }
}
