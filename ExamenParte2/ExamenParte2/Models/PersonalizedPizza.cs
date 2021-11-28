using System.ComponentModel.DataAnnotations;

namespace ExamenParte2.Models {
    public class PersonalizedPizza {
        [Required(ErrorMessage = "Es necesario que seleccione un tamaño")]
        [Display(Name = "Seleccione el tamaño")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Es necesario que seleccione un tipo de masa")]
        [Display(Name = "Seleccione la masa")]
        public string Mass { get; set; }

        [Required(ErrorMessage = "Es necesario que seleccione una opción")]
        [Display(Name = "¿Cuál es su salsa?")]
        public string Sauce { get; set; }

        [Required(ErrorMessage = "Es necesario que seleccione una opción")]
        [Display(Name = "¿Cuánta mozzarella le apetece?")]
        public string Mozzarella { get; set; }
    }
}