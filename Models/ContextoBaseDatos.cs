using Microsoft.EntityFrameworkCore; //Agregar librerías
using VIVEMAS.Models;

namespace VIVEMAS.Models
{
    public class ContextoBaseDatos : DbContext
    {
        public ContextoBaseDatos(DbContextOptions<ContextoBaseDatos> opt)
            : base(opt) { }
        public DbSet<VIVEMAS.Models.AccesoAdministrador> AccesoAdministrador { get; set; }
        public DbSet<VIVEMAS.Models.AccesoUsuario> AccesoUsuario { get; set; }
        public DbSet<VIVEMAS.Models.Administrador> Administrador { get; set; }
        public DbSet<VIVEMAS.Models.CatDiabetes> CatDiabetes { get; set; }
        public DbSet<VIVEMAS.Models.CatDificultad> CatDificultad { get; set; }
        public DbSet<VIVEMAS.Models.CatEstado> CatEstado { get; set; }
        public DbSet<VIVEMAS.Models.Platillo> Platillo { get; set; }
        public DbSet<VIVEMAS.Models.TipoEjercicio> TipoEjercicio { get; set; }
        public DbSet<VIVEMAS.Models.Ejercicio> Ejercicio { get; set; }
        public DbSet<VIVEMAS.Models.Rutina> Rutina { get; set; }
        public DbSet<VIVEMAS.Models.Usuario> Usuario { get; set; }
    }
}
