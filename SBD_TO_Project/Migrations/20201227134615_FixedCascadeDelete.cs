using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class FixedCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Cinema_IdCinema",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntry_Movie_IdMovie",
                table: "ScheduleEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntry_Schedule_IdSchedule",
                table: "ScheduleEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntry_ScreeningRoom_IdScreeningRoom",
                table: "ScheduleEntry");

            migrationBuilder.AlterColumn<int>(
                name: "IdScreeningRoom",
                table: "ScheduleEntry",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdSchedule",
                table: "ScheduleEntry",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdMovie",
                table: "ScheduleEntry",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Cinema_IdCinema",
                table: "Schedule",
                column: "IdCinema",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntry_Movie_IdMovie",
                table: "ScheduleEntry",
                column: "IdMovie",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntry_Schedule_IdSchedule",
                table: "ScheduleEntry",
                column: "IdSchedule",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntry_ScreeningRoom_IdScreeningRoom",
                table: "ScheduleEntry",
                column: "IdScreeningRoom",
                principalTable: "ScreeningRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Cinema_IdCinema",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntry_Movie_IdMovie",
                table: "ScheduleEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntry_Schedule_IdSchedule",
                table: "ScheduleEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntry_ScreeningRoom_IdScreeningRoom",
                table: "ScheduleEntry");

            migrationBuilder.AlterColumn<int>(
                name: "IdScreeningRoom",
                table: "ScheduleEntry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdSchedule",
                table: "ScheduleEntry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdMovie",
                table: "ScheduleEntry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "Schedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Cinema_IdCinema",
                table: "Schedule",
                column: "IdCinema",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntry_Movie_IdMovie",
                table: "ScheduleEntry",
                column: "IdMovie",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntry_Schedule_IdSchedule",
                table: "ScheduleEntry",
                column: "IdSchedule",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntry_ScreeningRoom_IdScreeningRoom",
                table: "ScheduleEntry",
                column: "IdScreeningRoom",
                principalTable: "ScreeningRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
