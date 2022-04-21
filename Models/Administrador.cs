using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VIVEMAS.Models
{
    public class Administrador
    {
        [Key]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "ID: ")]
        public int Admin_id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Disculpe, su nombre es demasiado largo, solo omitimos 30 caracteres :(")]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Disculpe, su apellido es demasiado largo, solo omitimos 30 caracteres :(")]
        [Display(Name = "Apellido Paterno: ")]
        public string ApPat { get; set; }

        [MaxLength(30, ErrorMessage = "Disculpe, su apellido es demasiado largo, solo omitimos 30 caracteres :(")]
        [Display(Name = "Apellido Materno: ")]
        public string ApMat { get; set; }

        [Display(Name = "Puesto: ")]
        public string Puesto { get; set; }

        [MaxLength(10, ErrorMessage = "El número que ingreso no contiene los 10 caracteres requeridos, omita espacios o guiones. Gracias.")]
        [Display(Name = "Celular: ")]
        public string Celular { get; set; }

        //Llave Foránea (Atributo)    
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Estado")]
        public int Estado_id { get; set; }
        //Relación a la tabla Estado (uno a uno)
        [ForeignKey("Estado_id")]
        public CatEstado CatEstado { get; set; }


        //Llave Foránea = Llave primaria (Atributo)   
        //Relación a la tabla AccesoAdministrador (uno a uno)
        [ForeignKey("Admin_id")]
        public AccesoAdministrador AccesoAdministrador { get; set; }
    }
}
