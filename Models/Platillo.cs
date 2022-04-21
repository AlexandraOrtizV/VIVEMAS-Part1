using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VIVEMAS.Models
{
    public class Platillo
    {
        [Key]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "ID")]
        public int Platillo_id { get; set; }

        [MaxLength(50, ErrorMessage = "El nombre del platillo es muy largo, solo permitimos un máximo de 50 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [MaxLength(100, ErrorMessage = "El numero de caracteres máximo (100) ha sido excedido")]
        [Display(Name = "Ingredientes:\n")]
        public string Ingredientes { get; set; }

        [Display(Name = "Procedimiento: \n")]
        public string Procedimiento { get; set; }

        [Display(Name = "Tiempo de preparación en minutos:")]
        public int Tiempo { get; set; }

        [Display(Name = "Porciones en rebanadas: ")]
        public int Porciones { get; set; }

        [Display(Name = "Calorias por porción en gramos: ")]
        public int Calorias { get; set; }
    }
}
