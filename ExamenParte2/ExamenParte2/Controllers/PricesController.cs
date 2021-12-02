using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ExamenParte2.Models;

namespace ExamenParte2.Controllers{
    public class PricesController : GenericController{

        public ActionResult ShowPrices(string header) {
            ViewBag.SelectedProducts = TempData["products"] as List<SelectedItem>;
            ViewBag.Header = header;
            ViewBag.PickUpOptions = GetDropdown(new List<string> { "Express", "Retiro en restaurante" });

            return View();
        }

        public ActionResult SetProducts(string selectedProduct) {
            ActionResult view = RedirectToAction("ShowPrices", "Prices", new { header = "Productos seleccionados" });
            List<SelectedItem> selectedProducts = new List<SelectedItem>();
            selectedProducts.Add(GetSelectedItem(selectedProduct, selectedProduct, 1));
            TempData["products"] = selectedProducts;

            return view;
        }

        public ActionResult Invoice() {
            ViewBag.PickUpModel = TempData["pickUpInformation"] as PickOrderInformation;
            ViewBag.Date = DateTime.Now;

            return View();
        }
    }
}