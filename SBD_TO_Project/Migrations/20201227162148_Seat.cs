using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class Seat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_ScreeningRoom_IdScreeningRoom",
                table: "Seat");

            migrationBuilder.AlterColumn<int>(
                name: "IdScreeningRoom",
                table: "Seat",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Seat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRows",
                table: "ScreeningRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeatsPerRow",
                table: "ScreeningRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_ScreeningRoom_IdScreeningRoom",
                table: "Seat",
                column: "IdScreeningRoom",
                principalTable: "ScreeningRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_ScreeningRoom_IdScreeningRoom",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "NumberOfRows",
                table: "ScreeningRoom");

            migrationBuilder.DropColumn(
                name: "NumberOfSeatsPerRow",
                table: "ScreeningRoom");

            migrationBuilder.AlterColumn<int>(
                name: "IdScreeningRoom",
                table: "Seat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_ScreeningRoom_IdScreeningRoom",
                table: "Seat",
                column: "IdScreeningRoom",
                principalTable: "ScreeningRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
