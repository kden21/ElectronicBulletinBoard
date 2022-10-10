using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class ReplaceEmailWithLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Accounts",
                newName: "Login");

            migrationBuilder.RenameIndex(
                name: "IX_Email",
                table: "Accounts",
                newName: "IX_Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Accounts",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Login",
                table: "Accounts",
                newName: "IX_Email");
        }
    }
}
