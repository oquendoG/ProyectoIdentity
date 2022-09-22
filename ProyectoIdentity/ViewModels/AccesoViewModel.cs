using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;

namespace ProyectoIdentity.ViewModels
{
    public class AccesoViewModel
    {

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Display(Name = "Recordar datos?")]
        public bool RemerberMe { get; set; }

        public string urlRetorno { get; set; }
    }
}
