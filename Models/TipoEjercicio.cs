using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VIVEMAS.Models
{
    public class TipoEjercicio
    {
        [Key]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "ID")]
        public int Tipo_id { get; set; }

        [MaxLength(50, ErrorMessage = "El numero de caracteres máximo (50) ha sido excedido")]
        public string Descripcion { get; set; }
    }
}
