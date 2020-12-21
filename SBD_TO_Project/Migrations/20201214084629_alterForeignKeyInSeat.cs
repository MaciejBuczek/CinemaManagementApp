using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class alterForeignKeyInSeat : Migration
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_ScreeningRoom_IdScreeningRoom",
                table: "Seat",
                column: "IdScreeningRoom",
                principalTable: "ScreeningRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
