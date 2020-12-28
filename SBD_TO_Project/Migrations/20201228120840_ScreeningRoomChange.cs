using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class ScreeningRoomChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ScreeningRoomNumber",
                table: "ScreeningRoom",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ScreeningRoomNumber",
                table: "ScreeningRoom",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
