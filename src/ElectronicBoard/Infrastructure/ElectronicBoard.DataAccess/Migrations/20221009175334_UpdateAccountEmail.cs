using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class UpdateAccountEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Email",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Email",
                table: "Accounts",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Email",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Email",
                table: "Accounts",
                column: "Email");
        }
    }
}
