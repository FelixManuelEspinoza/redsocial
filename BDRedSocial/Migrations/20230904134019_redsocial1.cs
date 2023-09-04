using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDRedSocial.Migrations
{
    /// <inheritdoc />
    public partial class redsocial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargosRed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCarRed = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    DescCargoRed = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IdTrabajador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargosRed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodPuesto = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IdTrabajador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trabajadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Edad = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IdPuesto = table.Column<int>(type: "int", nullable: false),
                    PuestosId = table.Column<int>(type: "int", nullable: true),
                    CargoRedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trabajadores_CargosRed_CargoRedId",
                        column: x => x.CargoRedId,
                        principalTable: "CargosRed",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trabajadores_Puestos_PuestosId",
                        column: x => x.PuestosId,
                        principalTable: "Puestos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_CargoRedId",
                table: "Trabajadores",
                column: "CargoRedId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajadores_PuestosId",
                table: "Trabajadores",
                column: "PuestosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajadores");

            migrationBuilder.DropTable(
                name: "CargosRed");

            migrationBuilder.DropTable(
                name: "Puestos");
        }
    }
}
