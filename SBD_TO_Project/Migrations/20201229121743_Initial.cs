using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    Town = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OpenTime = table.Column<DateTime>(nullable: true),
                    CloseTime = table.Column<DateTime>(nullable: true),
                    MovieStudio_Name = table.Column<string>(nullable: true),
                    EstablishedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Director_Alias = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SecurityLevel = table.Column<short>(nullable: true),
                    IsRegularCustomer = table.Column<bool>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Salary = table.Column<float>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IdManager = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    IdCinema = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Address_IdCinema",
                        column: x => x.IdCinema,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScreeningRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreeningRoomNumber = table.Column<string>(nullable: false),
                    NumberOfRows = table.Column<int>(nullable: false),
                    NumberOfSeatsPerRow = table.Column<int>(nullable: false),
                    IdCinema = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreeningRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScreeningRoom_Address_IdCinema",
                        column: x => x.IdCinema,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CinemaEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCinema = table.Column<int>(nullable: true),
                    IdEmployee = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    AgeRating = table.Column<int>(nullable: true),
                    Length = table.Column<TimeSpan>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    IdDirector = table.Column<int>(nullable: true),
                    IdMovieStudio = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Person_IdDirector",
                        column: x => x.IdDirector,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movie_Address_IdMovieStudio",
                        column: x => x.IdMovieStudio,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(nullable: false),
                    RowNumber = table.Column<int>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    IdScreeningRoom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_ScreeningRoom_IdScreeningRoom",
                        column: x => x.IdScreeningRoom,
                        principalTable: "ScreeningRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdActor = table.Column<int>(nullable: false),
                    IdMovie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Person_IdActor",
                        column: x => x.IdActor,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    CommentContent = table.Column<string>(nullable: false),
                    IdCustomer = table.Column<int>(nullable: true),
                    IdMovie = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Person_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMovie = table.Column<int>(nullable: false),
                    IdGenre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genre_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    IdMovie = table.Column<int>(nullable: false),
                    IdSchedule = table.Column<int>(nullable: false),
                    IdScreeningRoom = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleEntry_Movie_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleEntry_Schedule_IdSchedule",
                        column: x => x.IdSchedule,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleEntry_ScreeningRoom_IdScreeningRoom",
                        column: x => x.IdScreeningRoom,
                        principalTable: "ScreeningRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    IdCustomer = table.Column<int>(nullable: true),
                    IdSeat = table.Column<int>(nullable: true),
                    IdScheduleEntry = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Person_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Person",
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

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    IdReservation = table.Column<int>(nullable: false),
                    IdPayment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Payment_IdPayment",
                        column: x => x.IdPayment,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Reservation_IdReservation",
                        column: x => x.IdReservation,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(nullable: false),
                    ComplaintContent = table.Column<string>(nullable: false),
                    IdCustomer = table.Column<int>(nullable: true),
                    IdOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaint_Person_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaint_Order_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_IdActor",
                table: "ActorMovie",
                column: "IdActor");

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_IdMovie",
                table: "ActorMovie",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaEmployee_IdCinema",
                table: "CinemaEmployee",
                column: "IdCinema");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaEmployee_IdEmployee",
                table: "CinemaEmployee",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IdCustomer",
                table: "Comment",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IdMovie",
                table: "Comment",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_IdCustomer",
                table: "Complaint",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_IdOrder",
                table: "Complaint",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_IdDirector",
                table: "Movie",
                column: "IdDirector");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_IdMovieStudio",
                table: "Movie",
                column: "IdMovieStudio");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_IdGenre",
                table: "MovieGenre",
                column: "IdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_IdMovie",
                table: "MovieGenre",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdPayment",
                table: "Order",
                column: "IdPayment");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdReservation",
                table: "Order",
                column: "IdReservation");

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

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_IdCinema",
                table: "Schedule",
                column: "IdCinema");

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

            migrationBuilder.CreateIndex(
                name: "IX_ScreeningRoom_IdCinema",
                table: "ScreeningRoom",
                column: "IdCinema");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_IdScreeningRoom",
                table: "Seat",
                column: "IdScreeningRoom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "CinemaEmployee");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "ScheduleEntry");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "ScreeningRoom");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
