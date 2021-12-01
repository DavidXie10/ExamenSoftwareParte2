using System.ComponentModel.DataAnnotations;

namespace ExamenParte2.Models {
    public class PickOrderInformation {
        [Required(ErrorMessage = "Es necesario que seleccione la forma de retiro")]
        public string PickOrderChoice { get; set; }

        [Display(Name = "Dirección exacta")]
        [Required(ErrorMessage = "Es necesario que llene el campo")]
        public string ExactDirection { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Es necesario que seleccione una provincia")]
        public string Province { get; set; }

        [Display(Name = "Cantón")]
        [Required(ErrorMessage = "Es necesario que ingrese el cantón")]
        public string Canton { get; set; }

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "Es necesario que ingrese el distrito")]
        public string District { get; set; }

        [Display(Name = "Teléfono")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe ingresar números")]
        [Required(ErrorMessage = "Es necesario que ingrese su número de teléfono")]
        public int ContactNumber { get; set; }

        public string Total { get; set; }

        public string ProductName { get; set; }
    }
}