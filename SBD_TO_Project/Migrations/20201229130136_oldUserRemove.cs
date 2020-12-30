using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class oldUserRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Person_IdCustomer",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaint_Person_IdCustomer",
                table: "Complaint");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Person_IdCustomer",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "CinemaEmployee");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_IdCustomer",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Complaint_IdCustomer",
                table: "Complaint");

            migrationBuilder.DropIndex(
                name: "IX_Comment_IdCustomer",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "IdCustomer",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "IsRegularCustomer",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IdManager",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "SecurityLevel",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IdCustomer",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "IdCustomer",
                table: "Comment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCustomer",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRegularCustomer",
                table: "Person",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdManager",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "Person",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "SecurityLevel",
                table: "Person",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCustomer",
                table: "Complaint",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCustomer",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CinemaEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCinema = table.Column<int>(type: "int", nullable: true),
                    IdEmployee = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaEmployee_Address_IdCinema",
                        column: x => x.IdCinema,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CinemaEmployee_Person_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdCustomer",
                table: "Reservation",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_IdCustomer",
                table: "Complaint",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IdCustomer",
                table: "Comment",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaEmployee_IdCinema",
                table: "CinemaEmployee",
                column: "IdCinema");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaEmployee_IdEmployee",
                table: "CinemaEmployee",
                column: "IdEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Person_IdCustomer",
                table: "Comment",
                column: "IdCustomer",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaint_Person_IdCustomer",
                table: "Complaint",
                column: "IdCustomer",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Person_IdCustomer",
                table: "Reservation",
                column: "IdCustomer",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
