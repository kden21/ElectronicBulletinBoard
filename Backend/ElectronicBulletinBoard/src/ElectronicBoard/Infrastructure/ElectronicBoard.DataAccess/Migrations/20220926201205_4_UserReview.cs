using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class _4_UserReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_UserId",
                table: "UserReviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_UserEntity_UserId",
                table: "UserReviews",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_UserEntity_UserId",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_UserReviews_UserId",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserReviews");
        }
    }
}
