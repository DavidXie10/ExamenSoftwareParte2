using System.ComponentModel.DataAnnotations;

namespace ExamenParte2.Models {
    public class PersonalizedPizza {
        [Required(ErrorMessage = "Por favor seleccione un tamaño")]
        [Display(Name = "Seleccione el tamaño")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Por favor seleccione un tipo de masa")]
        [Display(Name = "Seleccione la masa")]
        public string Mass { get; set; }

        [Required(ErrorMessage = "Por favor seleccione una opción")]
        [Display(Name = "Seleccione una salsa")]
        public string Sauce { get; set; }

        [Required(ErrorMessage = "Por favor seleccione una opción")]
        [Display(Name = "Seleccione la cantidad de mozzarella")]
        public string Mozzarella { get; set; }
    }
}