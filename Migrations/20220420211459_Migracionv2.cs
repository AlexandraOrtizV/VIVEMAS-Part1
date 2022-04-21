using Microsoft.EntityFrameworkCore.Migrations;

namespace VIVEMAS.Migrations
{
    public partial class Migracionv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccesoAdministrador",
                columns: table => new
                {
                    Administrador_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(maxLength: 30, nullable: false),
                    Contraseña = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccesoAdministrador", x => x.Administrador_id);
                });

            migrationBuilder.CreateTable(
                name: "AccesoUsuario",
                columns: table => new
                {
                    Usuario_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(maxLength: 30, nullable: false),
                    Contraseña = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccesoUsuario", x => x.Usuario_id);
                });

            migrationBuilder.CreateTable(
                name: "CatDiabetes",
                columns: table => new
                {
                    Diabetes_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDiabetes", x => x.Diabetes_id);
                });

            migrationBuilder.CreateTable(
                name: "CatDificultad",
                columns: table => new
                {
                    Dificultad_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDificultad", x => x.Dificultad_id);
                });

            migrationBuilder.CreateTable(
                name: "CatEstado",
                columns: table => new
                {
                    Estado_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatEstado", x => x.Estado_id);
                });

            migrationBuilder.CreateTable(
                name: "Platillo",
                columns: table => new
                {
                    Platillo_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    Ingredientes = table.Column<string>(maxLength: 100, nullable: true),
                    Procedimiento = table.Column<string>(nullable: true),
                    Tiempo = table.Column<int>(nullable: false),
                    Porciones = table.Column<int>(nullable: false),
                    Calorias = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platillo", x => x.Platillo_id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEjercicio",
                columns: table => new
                {
                    Tipo_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEjercicio", x => x.Tipo_id);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Admin_id = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    ApPat = table.Column<string>(maxLength: 30, nullable: false),
                    ApMat = table.Column<string>(maxLength: 30, nullable: true),
                    Puesto = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(maxLength: 10, nullable: true),
                    Estado_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Admin_id);
                    table.ForeignKey(
                        name: "FK_Administrador_AccesoAdministrador_Admin_id",
                        column: x => x.Admin_id,
                        principalTable: "AccesoAdministrador",
                        principalColumn: "Administrador_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Administrador_CatEstado_Estado_id",
                        column: x => x.Estado_id,
                        principalTable: "CatEstado",
                        principalColumn: "Estado_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ejercicio",
                columns: table => new
                {
                    Ejercicio_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Tiempo = table.Column<int>(nullable: false),
                    Equipo = table.Column<string>(nullable: true),
                    Tipo_id = table.Column<int>(nullable: false),
                    Dificultad_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicio", x => x.Ejercicio_id);
                    table.ForeignKey(
                        name: "FK_Ejercicio_CatDificultad_Dificultad_id",
                        column: x => x.Dificultad_id,
                        principalTable: "CatDificultad",
                        principalColumn: "Dificultad_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ejercicio_TipoEjercicio_Tipo_id",
                        column: x => x.Tipo_id,
                        principalTable: "TipoEjercicio",
                        principalColumn: "Tipo_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rutina",
                columns: table => new
                {
                    Rutina_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Platillo_id = table.Column<int>(nullable: false),
                    Ejercicio_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutina", x => x.Rutina_id);
                    table.ForeignKey(
                        name: "FK_Rutina_Ejercicio_Ejercicio_id",
                        column: x => x.Ejercicio_id,
                        principalTable: "Ejercicio",
                        principalColumn: "Ejercicio_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rutina_Platillo_Platillo_id",
                        column: x => x.Platillo_id,
                        principalTable: "Platillo",
                        principalColumn: "Platillo_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Usuario_id = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    ApPat = table.Column<string>(maxLength: 30, nullable: false),
                    ApMat = table.Column<string>(maxLength: 30, nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Celular = table.Column<string>(maxLength: 10, nullable: true),
                    Estado_id = table.Column<int>(nullable: false),
                    Diabetes_id = table.Column<int>(nullable: false),
                    Rutina_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Usuario_id);
                    table.ForeignKey(
                        name: "FK_Usuario_CatDiabetes_Diabetes_id",
                        column: x => x.Diabetes_id,
                        principalTable: "CatDiabetes",
                        principalColumn: "Diabetes_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_CatEstado_Estado_id",
                        column: x => x.Estado_id,
                        principalTable: "CatEstado",
                        principalColumn: "Estado_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Rutina_Rutina_id",
                        column: x => x.Rutina_id,
                        principalTable: "Rutina",
                        principalColumn: "Rutina_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_AccesoUsuario_Usuario_id",
                        column: x => x.Usuario_id,
                        principalTable: "AccesoUsuario",
                        principalColumn: "Usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_Estado_id",
                table: "Administrador",
                column: "Estado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicio_Dificultad_id",
                table: "Ejercicio",
                column: "Dificultad_id");

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicio_Tipo_id",
                table: "Ejercicio",
                column: "Tipo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rutina_Ejercicio_id",
                table: "Rutina",
                column: "Ejercicio_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rutina_Platillo_id",
                table: "Rutina",
                column: "Platillo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Diabetes_id",
                table: "Usuario",
                column: "Diabetes_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Estado_id",
                table: "Usuario",
                column: "Estado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Rutina_id",
                table: "Usuario",
                column: "Rutina_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "AccesoAdministrador");

            migrationBuilder.DropTable(
                name: "CatDiabetes");

            migrationBuilder.DropTable(
                name: "CatEstado");

            migrationBuilder.DropTable(
                name: "Rutina");

            migrationBuilder.DropTable(
                name: "AccesoUsuario");

            migrationBuilder.DropTable(
                name: "Ejercicio");

            migrationBuilder.DropTable(
                name: "Platillo");

            migrationBuilder.DropTable(
                name: "CatDificultad");

            migrationBuilder.DropTable(
                name: "TipoEjercicio");
        }
    }
}
