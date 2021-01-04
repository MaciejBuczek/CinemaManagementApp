using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class ComplaintRelationAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaint_Order_IdOrder",
                table: "Complaint");

            migrationBuilder.AlterColumn<int>(
                name: "IdOrder",
                table: "Complaint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdCustomer",
                table: "Complaint",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Outcome",
                table: "Complaint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_IdCustomer",
                table: "Complaint",
                column: "IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaint_AspNetUsers_IdCustomer",
                table: "Complaint",
                column: "IdCustomer",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaint_Order_IdOrder",
                table: "Complaint",
                column: "IdOrder",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaint_AspNetUsers_IdCustomer",
                table: "Complaint");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaint_Order_IdOrder",
                table: "Complaint");

            migrationBuilder.DropIndex(
                name: "IX_Complaint_IdCustomer",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "IdCustomer",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "Outcome",
                table: "Complaint");

            migrationBuilder.AlterColumn<int>(
                name: "IdOrder",
                table: "Complaint",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Complaint_Order_IdOrder",
                table: "Complaint",
                column: "IdOrder",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
