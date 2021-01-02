using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class newCinemaEmployeeAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCinema = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaEmployee_Address_IdCinema",
                        column: x => x.IdCinema,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaEmployee_AspNetUsers_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "AspNetUsers",
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
        }
    }
}
