using System.ComponentModel.DataAnnotations;

namespace ExamenParte2.Models {
    public class PickOrderInformation {
        [Required(ErrorMessage = "Es necesario que seleccione la forma de retiro")]
        public string PickOrderChoice { get; set; }
    }
}