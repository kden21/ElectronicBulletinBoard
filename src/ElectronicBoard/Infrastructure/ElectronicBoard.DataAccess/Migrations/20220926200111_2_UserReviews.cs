using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class _2_UserReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_UserEntity_UserEntityId",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_UserReviews_UserEntityId",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "UserReviews");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "UserReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "AdvtReviewEntity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_AuthorId",
                table: "UserReviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvtReviewEntity_AuthorId",
                table: "AdvtReviewEntity",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtReviewEntity_UserEntity_AuthorId",
                table: "AdvtReviewEntity",
                column: "AuthorId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_UserEntity_AuthorId",
                table: "UserReviews",
                column: "AuthorId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReviewEntity_UserEntity_AuthorId",
                table: "AdvtReviewEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_UserEntity_AuthorId",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_UserReviews_AuthorId",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_AdvtReviewEntity_AuthorId",
                table: "AdvtReviewEntity");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "AdvtReviewEntity");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "UserReviews",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_UserEntityId",
                table: "UserReviews",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_UserEntity_UserEntityId",
                table: "UserReviews",
                column: "UserEntityId",
                principalTable: "UserEntity",
                principalColumn: "Id");
        }
    }
}
