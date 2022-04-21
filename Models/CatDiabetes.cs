using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VIVEMAS.Models
{
    public class CatDiabetes
    {
        [Key]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "ID")]
        public int Diabetes_id { get; set; }

        [MaxLength(15, ErrorMessage = "El numero de caracteres máximo (15) ha sido excedido")]
        public string Descripcion { get; set; }
    }
}
