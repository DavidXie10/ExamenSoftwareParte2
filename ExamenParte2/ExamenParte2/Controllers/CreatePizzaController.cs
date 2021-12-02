using System.Collections.Generic;
using System.Web.Mvc;
using ExamenParte2.Models;
using System;

namespace ExamenParte2.Controllers{
    public class CreatePizzaController : GenericController {
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
            TempData["Error"] = true;
            TempData["WarningMessage"] = "";

            try {
                AddPizzaSelection(selectedProducts, pizza);
                RequestIngredients(selectedProducts);
                TempData["Error"] = false;
                TempData["products"] = selectedProducts;
                ModelState.Clear();
                view = RedirectToAction("ShowPrices", "Prices", new {header = "Su pizza personalizada" });
            } catch {
                TempData["WarningMessage"] = "Algo salió mal";
            }

            return view;
        }

        private void AddPizzaSelection(List<SelectedItem> products, PersonalizedPizza pizza) {
            if (products != null) {
                products.Add(GetSelectedItem("Tamaño " + pizza.Size, pizza.Size, 1));
                products.Add(GetSelectedItem("Masa " + pizza.Mass, pizza.Mass, 1));
                products.Add(GetSelectedItem(pizza.Sauce, pizza.Sauce, 1));
                products.Add(GetSelectedItem(pizza.Mozzarella, pizza.Mozzarella, 1));
            }
        }

        private void RequestIngredients(List<SelectedItem> products) {
            if (products != null) {
                List<string> ingredients = ProductsDataAccess.GetItemsByType("ingrediente");
                foreach (string ingredient in ingredients) {
                    int quantity = Convert.ToInt32(Request.Form[ingredient]);
                    if (quantity > 0) {
                        products.Add(GetSelectedItem(ingredient, ingredient, quantity));
                    }
                }
            }
        }
    }
}