using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class removeFKFromCustomerUserEmployeeDirector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_User_IdUser",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Director_Person_IdPerson",
                table: "Director");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_User_IdUser",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Person_IdPerson",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdPerson",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Employee_IdUser",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Director_IdPerson",
                table: "Director");

            migrationBuilder.DropIndex(
                name: "IX_Customer_IdUser",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IdPerson",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IdPerson",
                table: "Director");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPerson",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPerson",
                table: "Director",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_IdPerson",
                table: "User",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdUser",
                table: "Employee",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Director_IdPerson",
                table: "Director",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdUser",
                table: "Customer",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_User_IdUser",
                table: "Customer",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Director_Person_IdPerson",
                table: "Director",
                column: "IdPerson",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_User_IdUser",
                table: "Employee",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Person_IdPerson",
                table: "User",
                column: "IdPerson",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
