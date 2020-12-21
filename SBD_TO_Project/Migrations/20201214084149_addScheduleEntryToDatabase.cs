using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class addScheduleEntryToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMovie = table.Column<int>(type: "int", nullable: true),
                    IdSchedule = table.Column<int>(type: "int", nullable: true),
                    IdScreeningRoom = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleEntry_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleEntry_Schedule_IdSchedule",
                        column: x => x.IdSchedule,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleEntry_ScreeningRoom_IdScreeningRoom",
                        column: x => x.IdScreeningRoom,
                        principalTable: "ScreeningRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntry_IdMovie",
                table: "ScheduleEntry",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntry_IdSchedule",
                table: "ScheduleEntry",
                column: "IdSchedule");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntry_IdScreeningRoom",
                table: "ScheduleEntry",
                column: "IdScreeningRoom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleEntry");
        }
    }
}
