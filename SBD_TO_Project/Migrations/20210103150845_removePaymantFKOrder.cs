using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class removePaymantFKOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Order_IdOrder",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_IdOrder",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "IdOrder",
                table: "Payment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdOrder",
                table: "Payment",
                type: "int",
                nullable: true);

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
        }
    }
}
