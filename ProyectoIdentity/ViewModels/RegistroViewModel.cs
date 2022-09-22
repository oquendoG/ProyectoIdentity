using System.ComponentModel.DataAnnotations;

namespace ProyectoIdentity.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(25, ErrorMessage = "El {0} debe estar entre al menos {2} caracteres de logitud", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmarContraseña { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }


        public string Url { get; set; }
        public Int32 CodigoPais { get; set; }
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Pais { get; set; }

        public string Ciudad { get; set; }
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool Estado { get; set; }
    }
}
