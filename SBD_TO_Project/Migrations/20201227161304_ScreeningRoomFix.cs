using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class ScreeningRoomFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntry_ScreeningRoom_IdScreeningRoom",
                table: "ScheduleEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ScreeningRoom_Cinema_IdCinema",
                table: "ScreeningRoom");

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

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "ScreeningRoom",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdScreeningRoom",
                table: "ScheduleEntry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntry_ScreeningRoom_IdScreeningRoom",
                table: "ScheduleEntry",
                column: "IdScreeningRoom",
                principalTable: "ScreeningRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScreeningRoom_Cinema_IdCinema",
                table: "ScreeningRoom",
                column: "IdCinema",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ScheduleEntry_ScreeningRoom_IdScreeningRoom",
                table: "ScheduleEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ScreeningRoom_Cinema_IdCinema",
                table: "ScreeningRoom");

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

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "ScreeningRoom",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdScreeningRoom",
                table: "ScheduleEntry",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntry_ScreeningRoom_IdScreeningRoom",
                table: "ScheduleEntry",
                column: "IdScreeningRoom",
                principalTable: "ScreeningRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScreeningRoom_Cinema_IdCinema",
                table: "ScreeningRoom",
                column: "IdCinema",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
