using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class EditAuthorInAdvtEntityConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advts_Users_UserId",
                table: "Advts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Advts",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Advts_UserId",
                table: "Advts",
                newName: "IX_Advts_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advts_Users_AuthorId",
                table: "Advts",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advts_Users_AuthorId",
                table: "Advts");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Advts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Advts_AuthorId",
                table: "Advts",
                newName: "IX_Advts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advts_Users_UserId",
                table: "Advts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
