using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenParte2.Models {
    public class SelectedItem {
        public string Description { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public int Total { get; set; }

        public void CalculateTotal (){
            this.Total = this.Quantity * this.Price;
        }
    }
}