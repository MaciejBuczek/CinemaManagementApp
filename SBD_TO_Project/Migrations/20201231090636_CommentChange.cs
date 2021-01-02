using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_TO_Project.Migrations
{
    public partial class CommentChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdCustomer",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Comment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IdCustomer",
                table: "Comment",
                column: "IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_IdCustomer",
                table: "Comment",
                column: "IdCustomer",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_IdCustomer",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_IdCustomer",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "IdCustomer",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Comment");
        }
    }
}
