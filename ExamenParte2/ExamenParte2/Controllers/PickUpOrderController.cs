﻿using System;
using ExamenParte2.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace ExamenParte2.Controllers{
    public class PickUpOrderController : GenericController {
        private string[] LOCATIONS = { "Pizza Hut Guacima (Plaza Castillo)", "Pizza Hut Tibás (Centro comercial Plaza del Valle)", "Pizza Hut Escazú (Frente Perimercado Los Anonos)", "Pizza Hut Paseo Colón (Frente al Hotel Ambásador sobre el Paseo Colón)", "Pizza Hut Guadalupe (Centro Comercial Guadalupe)", "Pizza Hut Sabanilla (Sabanilla, Centro Comercial Vistana)", "Pizza Hut San Ramón (San Ramón Centro, Alajuela)" };

        private string[] PROVINCES = { "SAN JOSÉ", "ALAJUELA", "CARTAGO", "HEREDIA", "GUANACASTE", "PUNTARENAS", "LIMÓN" };

        private PickOrderInformation SetPickUpData(PickOrderInformation pickUpChoice) {
            string productName = Request.Form["productName"];
            string totalHidden = Request.Form["totalHidden"];
            string pickOrderChoice = Request.Form["pickOrder"];

            pickUpChoice.ProductName = productName;
            pickUpChoice.Total = totalHidden;
            pickUpChoice.PickOrderChoice = pickOrderChoice;

            return pickUpChoice;
        }

        [HttpPost]
        public ActionResult SubmitPickUpOrderChoice(PickOrderInformation pickUpChoice) {
            ActionResult view = RedirectToAction("Index", "Home");
            try {
                string choice = pickUpChoice.PickOrderChoice;
                string controllerMethod = choice == "Express" ? "Express" : "InRestaurant";

                pickUpChoice = SetPickUpData(pickUpChoice);

                TempData["pickUpInformation"] = pickUpChoice;
                view = RedirectToAction(controllerMethod, "PickUpOrder");
            } catch (Exception exception) {
              Debug.WriteLine(exception.ToString());
            }

            return view;
        }

        public ActionResult InRestaurant() {
            ViewBag.PickUpModel = TempData["pickUpInformation"] as PickOrderInformation;
            ViewBag.Restaurants = GetDropdown(new List<string>(LOCATIONS));

            return View();
        }

        public ActionResult Express() {
            ViewBag.PickUpModel = TempData["pickUpInformation"] as PickOrderInformation;
            ViewBag.Provinces = GetDropdown(new List<string>(PROVINCES));

            return View();
        }

        [HttpPost]
        public ActionResult SubmitPickUpInformation(PickOrderInformation pickUpChoice) {
            ActionResult view = RedirectToAction("Index", "Home");

            try {
                pickUpChoice = SetPickUpData(pickUpChoice);
                TempData["pickUpInformation"] = pickUpChoice;
                view = RedirectToAction("Invoice", "Prices");
            } catch (Exception exception) {
                Debug.WriteLine(exception.ToString());
            }

            return view;
        }
    }
}