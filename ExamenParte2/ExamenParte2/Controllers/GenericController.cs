using ExamenParte2.Handlers;
using ExamenParte2.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ExamenParte2.Controllers{
    public class GenericController : Controller{
        protected ProductsHandler ProductsDataAccess { get; set; }

        public GenericController() {
            ProductsDataAccess = new ProductsHandler();
        }

        protected List<SelectListItem> GetDropdown(List<string> options) {
            List<SelectListItem> dropdown = new List<SelectListItem>();

            foreach (string option in options) {
                dropdown.Add(new SelectListItem { Text = option, Value = option });
            }

            return dropdown;
        }

        protected SelectedItem GetSelectedItem(string description, string findPrice, int quantity) {
            return new SelectedItem(description, ProductsDataAccess.GetPriceForItem(findPrice), quantity);
        }
    }
}