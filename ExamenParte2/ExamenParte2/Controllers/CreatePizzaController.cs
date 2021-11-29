using System.Collections.Generic;
using System.Web.Mvc;
using ExamenParte2.Models;
using ExamenParte2.Handlers;

namespace ExamenParte2.Controllers{
    public class CreatePizzaController : Controller{
        ProductsHandler ProductsDataAccess { get; set; }

        public CreatePizzaController() {
            ProductsDataAccess = new ProductsHandler();
        }

        private List<SelectListItem> GetDropdown(List<string> options) {
            List<SelectListItem> dropdown = new List<SelectListItem>();

            foreach (string option in options) {
                dropdown.Add(new SelectListItem { Text = option, Value = option });
            }

            return dropdown;
        }

        public ActionResult CreatePizza(){
            ViewBag.Sizes = GetDropdown(ProductsDataAccess.GetItemsByType("tamanio"));
            ViewBag.Masses = GetDropdown(ProductsDataAccess.GetItemsByType("masa"));
            ViewBag.Sauces = GetDropdown(ProductsDataAccess.GetItemsByType("salsa"));
            ViewBag.Mozzarellas = GetDropdown(ProductsDataAccess.GetItemsByType("mozzarella"));

            return View();
        }

        [HttpPost]
        public ActionResult SubmitPizzaCreation(PersonalizedPizza pizza) {
            List<SelectedItem> selectedProducts = new List<SelectedItem>();
            ActionResult view = RedirectToAction("Index", "Home");
            //string date = Request.Form["date"];
            //string title = Request.Form["title"];
            TempData["Error"] = true;
            TempData["WarningMessage"] = "";

            try {
                TempData["Error"] = false;
                ModelState.Clear();
                view = RedirectToAction("ShowPrices", "CreatePizza", new {products = selectedProducts });
            } catch {
                TempData["WarningMessage"] = "Algo salió mal";
            }

            return view;
        }

        public ActionResult ShowPrices(List<SelectedItem> products) {
            ViewBag.SelectedProducts = products;
            return View();
        }
    }
}