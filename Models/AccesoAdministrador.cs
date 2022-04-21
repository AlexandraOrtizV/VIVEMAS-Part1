using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VIVEMAS.Models
{
    public class AccesoAdministrador
    {
        [Key]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "ID")]
        public int Administrador_id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El correo que ha ingresado es demasiado larga, solo permitimos 30 caracteres.")]
        [MinLength(6, ErrorMessage = "El correo que ha ingresado es demasiado corto, permitimos un mìnimo de 6 caracteres.")]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(8, ErrorMessage = "Por su seguridad, la contraseña debe contener 8 caracteres.")]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }
    }
}
