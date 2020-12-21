using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class alterForeignKeysInDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaMenager_Cinema_IdCinema",
                table: "CinemaMenager");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaMenager_Employee_IdEmployee",
                table: "CinemaMenager");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Director_IdDirector",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieStudo_IdMovieStudio",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genre_IdGenre",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movie_IdMovie",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Cinema_IdCinema",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ScreeningRoom_Cinema_IdCinema",
                table: "ScreeningRoom");

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "ScreeningRoom",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "Schedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdMovie",
                table: "MovieGenre",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdGenre",
                table: "MovieGenre",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdMovieStudio",
                table: "Movie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdDirector",
                table: "Movie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdEmployee",
                table: "CinemaMenager",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "CinemaMenager",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaMenager_Cinema_IdCinema",
                table: "CinemaMenager",
                column: "IdCinema",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaMenager_Employee_IdEmployee",
                table: "CinemaMenager",
                column: "IdEmployee",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_IdDirector",
                table: "Movie",
                column: "IdDirector",
                principalTable: "Director",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieStudo_IdMovieStudio",
                table: "Movie",
                column: "IdMovieStudio",
                principalTable: "MovieStudo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Genre_IdGenre",
                table: "MovieGenre",
                column: "IdGenre",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movie_IdMovie",
                table: "MovieGenre",
                column: "IdMovie",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Cinema_IdCinema",
                table: "Schedule",
                column: "IdCinema",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScreeningRoom_Cinema_IdCinema",
                table: "ScreeningRoom",
                column: "IdCinema",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaMenager_Cinema_IdCinema",
                table: "CinemaMenager");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaMenager_Employee_IdEmployee",
                table: "CinemaMenager");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Director_IdDirector",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieStudo_IdMovieStudio",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genre_IdGenre",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movie_IdMovie",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Cinema_IdCinema",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ScreeningRoom_Cinema_IdCinema",
                table: "ScreeningRoom");

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "ScreeningRoom",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdMovie",
                table: "MovieGenre",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdGenre",
                table: "MovieGenre",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdMovieStudio",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdDirector",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdEmployee",
                table: "CinemaMenager",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCinema",
                table: "CinemaMenager",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaMenager_Cinema_IdCinema",
                table: "CinemaMenager",
                column: "IdCinema",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaMenager_Employee_IdEmployee",
                table: "CinemaMenager",
                column: "IdEmployee",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Director_IdDirector",
                table: "Movie",
                column: "IdDirector",
                principalTable: "Director",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieStudo_IdMovieStudio",
                table: "Movie",
                column: "IdMovieStudio",
                principalTable: "MovieStudo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Genre_IdGenre",
                table: "MovieGenre",
                column: "IdGenre",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movie_IdMovie",
                table: "MovieGenre",
                column: "IdMovie",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Cinema_IdCinema",
                table: "Schedule",
                column: "IdCinema",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScreeningRoom_Cinema_IdCinema",
                table: "ScreeningRoom",
                column: "IdCinema",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
