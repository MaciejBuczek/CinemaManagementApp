using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class addComplaintToDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Customer_IdCustomer",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Order_IdOrder",
                table: "Complaints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints");

            migrationBuilder.RenameTable(
                name: "Complaints",
                newName: "Complaint");

            migrationBuilder.RenameIndex(
                name: "IX_Complaints_IdOrder",
                table: "Complaint",
                newName: "IX_Complaint_IdOrder");

            migrationBuilder.RenameIndex(
                name: "IX_Complaints_IdCustomer",
                table: "Complaint",
                newName: "IX_Complaint_IdCustomer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complaint",
                table: "Complaint",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaint_Customer_IdCustomer",
                table: "Complaint",
                column: "IdCustomer",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaint_Order_IdOrder",
                table: "Complaint",
                column: "IdOrder",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaint_Customer_IdCustomer",
                table: "Complaint");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaint_Order_IdOrder",
                table: "Complaint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Complaint",
                table: "Complaint");

            migrationBuilder.RenameTable(
                name: "Complaint",
                newName: "Complaints");

            migrationBuilder.RenameIndex(
                name: "IX_Complaint_IdOrder",
                table: "Complaints",
                newName: "IX_Complaints_IdOrder");

            migrationBuilder.RenameIndex(
                name: "IX_Complaint_IdCustomer",
                table: "Complaints",
                newName: "IX_Complaints_IdCustomer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Complaints",
                table: "Complaints",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Customer_IdCustomer",
                table: "Complaints",
                column: "IdCustomer",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Order_IdOrder",
                table: "Complaints",
                column: "IdOrder",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
