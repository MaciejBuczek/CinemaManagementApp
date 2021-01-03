using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class OrderRelationsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Reservation_IdReservation",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_IdReservation",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IdReservation",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "IdOrder",
                table: "Reservation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdOrder",
                table: "Payment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdOrder",
                table: "Reservation",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdOrder",
                table: "Payment",
                column: "IdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Order_IdOrder",
                table: "Payment",
                column: "IdOrder",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Order_IdOrder",
                table: "Reservation",
                column: "IdOrder",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Order_IdOrder",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Order_IdOrder",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_IdOrder",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Payment_IdOrder",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "IdOrder",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "IdOrder",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "IdReservation",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdReservation",
                table: "Order",
                column: "IdReservation");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Reservation_IdReservation",
                table: "Order",
                column: "IdReservation",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
