using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class ActorForeignKeyDrop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actor_Person_IdPerson",
                table: "Actor");

            migrationBuilder.DropIndex(
                name: "IX_Actor_IdPerson",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "IdPerson",
                table: "Actor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPerson",
                table: "Actor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Actor_IdPerson",
                table: "Actor",
                column: "IdPerson");

            migrationBuilder.AddForeignKey(
                name: "FK_Actor_Person_IdPerson",
                table: "Actor",
                column: "IdPerson",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
