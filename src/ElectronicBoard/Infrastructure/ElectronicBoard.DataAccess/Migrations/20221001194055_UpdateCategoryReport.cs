using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class UpdateCategoryReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryReportId",
                table: "UserReports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryReportId",
                table: "AdvtReports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserReports_CategoryReportId",
                table: "UserReports",
                column: "CategoryReportId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvtReports_CategoryReportId",
                table: "AdvtReports",
                column: "CategoryReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtReports_CategoriesReport_CategoryReportId",
                table: "AdvtReports",
                column: "CategoryReportId",
                principalTable: "CategoriesReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReports_CategoriesReport_CategoryReportId",
                table: "UserReports",
                column: "CategoryReportId",
                principalTable: "CategoriesReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReports_CategoriesReport_CategoryReportId",
                table: "AdvtReports");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReports_CategoriesReport_CategoryReportId",
                table: "UserReports");

            migrationBuilder.DropIndex(
                name: "IX_UserReports_CategoryReportId",
                table: "UserReports");

            migrationBuilder.DropIndex(
                name: "IX_AdvtReports_CategoryReportId",
                table: "AdvtReports");

            migrationBuilder.DropColumn(
                name: "CategoryReportId",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "CategoryReportId",
                table: "AdvtReports");
        }
    }
}
