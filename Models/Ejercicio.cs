using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VIVEMAS.Models
{
    public class Ejercicio
    {
        [Key]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "ID")]
        public int Ejercicio_id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre del ejercicio es muy largo, solo permitimos un máximo de 50 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción: \n")]
        public string Descripcion { get; set; }

        [Display(Name = "Tiempo de ejecución en minutos:")]
        public int Tiempo { get; set; }

        [Display(Name = "Equipo requerido: ")]
        public string Equipo { get; set; }

        //Llave Foránea Tipo de Ejercicio
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = " Tipo de ejercicio: ")]
        public int Tipo_id { get; set; }
        //Relación con la tabla TipoEjercicio (uno a uno)
        [ForeignKey("Tipo_id")]
        public TipoEjercicio TipoEjercicio { get; set; }

        //Lave Foránea dificultad de l ejercicio
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Dificultad del ejercicio: ")]
        public int Dificultad_id { get; set; }
        //Relación con la tabla CatDificultad (uno a uno)
        [ForeignKey("Dificultad_id")]
        public CatDificultad CatDificultad { get; set; }
    }
}
