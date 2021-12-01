using System.ComponentModel.DataAnnotations;

namespace ExamenParte2.Models {
    public class PickOrderInformation {
        [Required(ErrorMessage = "Es necesario que seleccione la forma de retiro")]
        public string PickOrderChoice { get; set; }

        [Display(Name = "Dirección exacta")]
        [Required(ErrorMessage = "Es necesario que llene el campo")]
        public string ExactDirection { get; set; }

        public string Province { get; set; }

        public string Canton { get; set; }

        public string District { get; set; }

        public int Total { get; set; }

        public string ProductName { get; set; }
    }
}