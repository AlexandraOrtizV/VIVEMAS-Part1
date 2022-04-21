using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VIVEMAS.Models
{
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "ID: ")]
        public int Usuario_id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(30)]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(30, ErrorMessage = "Disculpe, su apellido es demasiado largo, solo omitimos 30 caracteres :(")]
        [Display(Name = "Apellido Paterno: ")]
        public string ApPat { get; set; }

        [MaxLength(30, ErrorMessage = "Disculpe, su apellido es demasiado largo, solo omitimos 30 caracteres :(")]
        [Display(Name = "Apellido Materno: ")]
        public string ApMat { get; set; }

        [Display(Name = "Edad: ")]
        public int Edad { get; set; }

        [MaxLength(10, ErrorMessage = "El número que ingreso contiene más de 10 caracteres, omita espacios o guiones. Gracias.")]
        [Display(Name = "Celular: ")]
        public string Celular { get; set; }


        //Llave Foránea (Atributo)    
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Estado")]
        public int Estado_id { get; set; }
        //Relación a la tabla Estado (uno a uno)
        [ForeignKey("Estado_id")]
        public CatEstado CatEstado { get; set; }


        //Llave Foránea (Atributo)   
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Diabetes")]
        public int Diabetes_id { get; set; }
        //Relación a la tabla CatDiabetes (uno a uno)
        [ForeignKey("Diabetes_id")]
        public CatDiabetes CatDiabetes { get; set; }


        //Llave Foránea (Atributo)   
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Rutina")]
        public int Rutina_id { get; set; }
        //Relación a la tabla Rutina (uno a uno)
        [ForeignKey("Rutina_id")]
        public Rutina Rutina { get; set; }


        //Llave Foránea = Llave primaria (Atributo)   
        //Relación a la tabla AccesoUsuario (uno a uno)
        [ForeignKey("Usuario_id")]
        public AccesoUsuario AccesoUsuario { get; set; }
    }
}
