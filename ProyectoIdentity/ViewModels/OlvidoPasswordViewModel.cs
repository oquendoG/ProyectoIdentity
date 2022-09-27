using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;

namespace ProyectoIdentity.ViewModels
{
    public class OlvidoPasswordViewModel
    {

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }
}
