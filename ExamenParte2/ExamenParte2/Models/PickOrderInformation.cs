using System.ComponentModel.DataAnnotations;

namespace ExamenParte2.Models {
    public class PickOrderInformation {
        [Required(ErrorMessage = "Por favor seleccione la forma de retiro")]
        public string PickOrderChoice { get; set; }

        [Display(Name = "Dirección exacta")]
        [Required(ErrorMessage = "Por favor llene el campo")]
        public string ExactDirection { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Por favor seleccione una provincia")]
        public string Province { get; set; }

        [Display(Name = "Cantón")]
        [Required(ErrorMessage = "Por favor ingrese el cantón")]
        public string Canton { get; set; }

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "Por favor ingrese el distrito")]
        public string District { get; set; }

        [Display(Name = "Teléfono")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe ingresar números")]
        [Required(ErrorMessage = "Por favor ingrese su número de teléfono")]
        public int ContactNumber { get; set; }

        public string Total { get; set; }

        public string ProductName { get; set; }
    }
}