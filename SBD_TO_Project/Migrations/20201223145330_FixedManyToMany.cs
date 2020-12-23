using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class FixedManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaMenager");

            migrationBuilder.CreateTable(
                name: "CinemaEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCinema = table.Column<int>(type: "int", nullable: true),
                    IdEmployee = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaEmployee_Cinema_IdCinema",
                        column: x => x.IdCinema,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CinemaEmployee_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaEmployee_IdCinema",
                table: "CinemaEmployee",
                column: "IdCinema");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaEmployee_IdEmployee",
                table: "CinemaEmployee",
                column: "IdEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaEmployee");

            migrationBuilder.CreateTable(
                name: "CinemaMenager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCinema = table.Column<int>(type: "int", nullable: true),
                    IdEmployee = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaMenager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaMenager_Cinema_IdCinema",
                        column: x => x.IdCinema,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CinemaMenager_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMenager_IdCinema",
                table: "CinemaMenager",
                column: "IdCinema");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMenager_IdEmployee",
                table: "CinemaMenager",
                column: "IdEmployee");
        }
    }
}
