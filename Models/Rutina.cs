using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VIVEMAS.Models
{
    public class Rutina
    {
        [Key]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "ID")]
        public int Rutina_id { get; set; }

        //Llave Foránea Platillo_id (Atributo)
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Platillo: ")]
        public int Platillo_id { get; set; }
        //Relación con la tabla Platillo (uno a uno)
        [ForeignKey("Platillo_id")]
        public Platillo Platillo { get; set; }

        //Llave Foránea Ejercicio_id (Atributo)
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Ejercicio: ")]
        public int Ejercicio_id { get; set; }
        //Relación con la tabla Ejercicio (uno a uno)
        [ForeignKey("Ejercicio_id")]
        public Ejercicio Ejercicio { get; set; }
    }
}
