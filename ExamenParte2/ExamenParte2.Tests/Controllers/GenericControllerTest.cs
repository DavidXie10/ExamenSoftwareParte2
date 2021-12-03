using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamenParte2.Controllers;
using ExamenParte2.Models;

namespace ExamenParte2.Tests.Controllers {
    [TestClass]
    public class GenericControllerTest {
        [TestMethod]
        public void TestSelectedItemDescriptionValueIsCorrect() {
            GenericController genericController = new GenericController();
            SelectedItem expected = new SelectedItem("Pepperoni", 200, 2);
            SelectedItem actual = genericController.GetSelectedItem("Pepperoni", "Pepperoni", 2);
            Assert.AreEqual(expected.Description, actual.Description);
        }

        [TestMethod]
        public void TestSelectedItemPriceValueIsCorrect() {
            GenericController genericController = new GenericController();
            SelectedItem expected = new SelectedItem("Pepperoni", 500, 2);
            SelectedItem actual = genericController.GetSelectedItem("Pepperoni", "Pepperoni", 2);
            Assert.AreEqual(expected.Price, actual.Price);
        }

        [TestMethod]
        public void TestSelectedItemQuantityValueIsCorrect() {
            GenericController genericController = new GenericController();
            SelectedItem expected = new SelectedItem("Pepperoni", 100, 2);
            SelectedItem actual = genericController.GetSelectedItem("Pepperoni", "Pepperoni", 2);
            Assert.AreEqual(expected.Quantity, actual.Quantity);
        }

        [TestMethod]
        public void TestSelectedItemTotalValueIsCorrect() {
            GenericController genericController = new GenericController();
            SelectedItem expected = new SelectedItem("Pepperoni", 500, 2);
            SelectedItem actual = genericController.GetSelectedItem("Pepperoni", "Pepperoni", 2);
            Assert.AreEqual(expected.Total, actual.Total);
        }
    }
}
