using System;
using ExamenParte2.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ExamenParte2.Controllers{
    public class PickUpOrderController : Controller {
        private string[] LOCATIONS = { "Pizza Hut Guacima (Plaza Castillo)", "Pizza Hut Tibás (Centro comercial Plaza del Valle)", "Pizza Hut Escazú (Frente Perimercado Los Anonos)", "Pizza Hut Paseo Colón (Frente al Hotel Ambásador sobre el Paseo Colón)", "Pizza Hut Guadalupe (Centro Comercial Guadalupe)", "Pizza Hut Sabanilla (Sabanilla, Centro Comercial Vistana)", "Pizza Hut San Ramón (San Ramón Centro, Alajuela)" };

        [HttpPost]
        public ActionResult SubmitPickUpOrderChoice(PickOrderInformation pickUpChoice) {
            string choice = pickUpChoice.PickOrderChoice;
            string controllerMethod = choice == "Express" ? "Express" : "InRestaurant";
            string productName = Request.Form["productName"];
            int total = int.Parse(Request.Form["totalHidden"]);

            pickUpChoice.ProductName = productName;
            pickUpChoice.Total = total;

            TempData["pickUpInformation"] = pickUpChoice;
            ActionResult view = RedirectToAction(controllerMethod, "PickUpOrder");

            return view;
        }

        private List<SelectListItem> GetDropdown(List<string> options) {
            List<SelectListItem> dropdown = new List<SelectListItem>();

            foreach (string option in options) {
                dropdown.Add(new SelectListItem { Text = option, Value = option });
            }

            return dropdown;
        }

        public ActionResult InRestaurant() {
            ViewBag.PickUpModel = TempData["pickUpInformation"] as PickOrderInformation;
            ViewBag.Restaurants = GetDropdown(new List<string>(LOCATIONS));

            return View();
        }

        [HttpPost]
        public ActionResult SubmitInRestaurantChoice(PickOrderInformation pickUpChoice) {
            string productName = Request.Form["productName"];
            int total = Convert.ToInt32(Request.Form["totalHidden"]);

            pickUpChoice.Total = total;
            pickUpChoice.ProductName = productName;

            TempData["pickUpInformation"] = pickUpChoice;

            ActionResult view = RedirectToAction("Invoice", "PickUpOrder");

            return view;
        }

        public ActionResult Express() {
            ViewBag.PickUpModel = TempData["pickUpInformation"] as PickOrderInformation;

            return View();
        }

        [HttpPost]
        public ActionResult SubmitExpressChoice(PickOrderInformation pickUpChoice) {

            return View();
        }

        public ActionResult Invoice() {
            return View();
        }
    }
}