using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class addReservationToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCustomer = table.Column<int>(type: "int", nullable: true),
                    IdSeat = table.Column<int>(type: "int", nullable: true),
                    IdScheduleEntry = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Customer_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_ScheduleEntry_IdScheduleEntry",
                        column: x => x.IdScheduleEntry,
                        principalTable: "ScheduleEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Seat_IdSeat",
                        column: x => x.IdSeat,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdCustomer",
                table: "Reservation",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdScheduleEntry",
                table: "Reservation",
                column: "IdScheduleEntry");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdSeat",
                table: "Reservation",
                column: "IdSeat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");
        }
    }
}
