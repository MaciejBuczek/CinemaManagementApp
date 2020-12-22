using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class removeFKFromMovieStudioCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinema_Address_IdAddress",
                table: "Cinema");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudio_Address_IdAddress",
                table: "MovieStudio");

            migrationBuilder.DropIndex(
                name: "IX_MovieStudio_IdAddress",
                table: "MovieStudio");

            migrationBuilder.DropIndex(
                name: "IX_Cinema_IdAddress",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "IdAddress",
                table: "MovieStudio");

            migrationBuilder.DropColumn(
                name: "IdAddress",
                table: "Cinema");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAddress",
                table: "MovieStudio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAddress",
                table: "Cinema",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovieStudio_IdAddress",
                table: "MovieStudio",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Cinema_IdAddress",
                table: "Cinema",
                column: "IdAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinema_Address_IdAddress",
                table: "Cinema",
                column: "IdAddress",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudio_Address_IdAddress",
                table: "MovieStudio",
                column: "IdAddress",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
