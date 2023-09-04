using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDRedSocial.Migrations
{
    /// <inheritdoc />
    public partial class Puesto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargosRed",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCarRed = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    DescCargoRed = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargosRed", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Edad = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CargoRedID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trabajadores_CargosRed_CargoRedID",
                        column: x => x.CargoRedID,
                        principalTable: "CargosRed",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "puestos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodPuesto = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IDTrabajador = table.Column<int>(type: "int", nullable: false),
                    TrabajadorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puestos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_puestos_Trabajadores_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajadores",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "Codigo_Cargo_Red",
                table: "CargosRed",
                column: "CodCarRed",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Codigo_Puesto",
                table: "puestos",
                column: "CodPuesto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_puestos_TrabajadorID",
                table: "puestos",
                column: "TrabajadorID");

            migrationBuilder.CreateIndex(
                name: "Correo_Trabajador",
                table: "Trabajadores",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_CargoRedID",
                table: "Trabajadores",
                column: "CargoRedID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "puestos");

            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "CargosRed");
        }
    }
}
