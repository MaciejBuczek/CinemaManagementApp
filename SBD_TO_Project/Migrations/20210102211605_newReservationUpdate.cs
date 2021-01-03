using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class newReservationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ScheduleEntry_IdScheduleEntry",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Seat_IdSeat",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "IdSeat",
                table: "Reservation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdScheduleEntry",
                table: "Reservation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdCustomer",
                table: "Reservation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdCustomer",
                table: "Reservation",
                column: "IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_AspNetUsers_IdCustomer",
                table: "Reservation",
                column: "IdCustomer",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ScheduleEntry_IdScheduleEntry",
                table: "Reservation",
                column: "IdScheduleEntry",
                principalTable: "ScheduleEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Seat_IdSeat",
                table: "Reservation",
                column: "IdSeat",
                principalTable: "Seat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_AspNetUsers_IdCustomer",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ScheduleEntry_IdScheduleEntry",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Seat_IdSeat",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_IdCustomer",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "IdCustomer",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "IdSeat",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdScheduleEntry",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ScheduleEntry_IdScheduleEntry",
                table: "Reservation",
                column: "IdScheduleEntry",
                principalTable: "ScheduleEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Seat_IdSeat",
                table: "Reservation",
                column: "IdSeat",
                principalTable: "Seat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
