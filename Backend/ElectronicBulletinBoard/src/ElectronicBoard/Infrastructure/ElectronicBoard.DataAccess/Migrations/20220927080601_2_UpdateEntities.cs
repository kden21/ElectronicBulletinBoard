using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class _2_UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvtEntity_CategoryEntity_CategoryEntityId",
                table: "AdvtEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReviewEntity_AdvtEntity_AdvtId",
                table: "AdvtReviewEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReviewEntity_UserEntity_AuthorId",
                table: "AdvtReviewEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId1",
                table: "CategoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvtReviewEntity",
                table: "AdvtReviewEntity");

            migrationBuilder.RenameTable(
                name: "AdvtReviewEntity",
                newName: "AdvtReviews");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId1",
                table: "CategoryEntity",
                newName: "ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEntity_ParentCategoryId1",
                table: "CategoryEntity",
                newName: "IX_CategoryEntity_ParentCategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryEntityId",
                table: "AdvtEntity",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtEntity_CategoryEntityId",
                table: "AdvtEntity",
                newName: "IX_AdvtEntity_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtReviewEntity_AuthorId",
                table: "AdvtReviews",
                newName: "IX_AdvtReviews_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtReviewEntity_AdvtId",
                table: "AdvtReviews",
                newName: "IX_AdvtReviews_AdvtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvtReviews",
                table: "AdvtReviews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtEntity_CategoryEntity_CategoryId",
                table: "AdvtEntity",
                column: "CategoryId",
                principalTable: "CategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtReviews_AdvtEntity_AdvtId",
                table: "AdvtReviews",
                column: "AdvtId",
                principalTable: "AdvtEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtReviews_UserEntity_AuthorId",
                table: "AdvtReviews",
                column: "AuthorId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId",
                table: "CategoryEntity",
                column: "ParentCategoryId",
                principalTable: "CategoryEntity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvtEntity_CategoryEntity_CategoryId",
                table: "AdvtEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReviews_AdvtEntity_AdvtId",
                table: "AdvtReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReviews_UserEntity_AuthorId",
                table: "AdvtReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId",
                table: "CategoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvtReviews",
                table: "AdvtReviews");

            migrationBuilder.RenameTable(
                name: "AdvtReviews",
                newName: "AdvtReviewEntity");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "CategoryEntity",
                newName: "ParentCategoryId1");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEntity_ParentCategoryId",
                table: "CategoryEntity",
                newName: "IX_CategoryEntity_ParentCategoryId1");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "AdvtEntity",
                newName: "CategoryEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtEntity_CategoryId",
                table: "AdvtEntity",
                newName: "IX_AdvtEntity_CategoryEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtReviews_AuthorId",
                table: "AdvtReviewEntity",
                newName: "IX_AdvtReviewEntity_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtReviews_AdvtId",
                table: "AdvtReviewEntity",
                newName: "IX_AdvtReviewEntity_AdvtId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvtReviewEntity",
                table: "AdvtReviewEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtEntity_CategoryEntity_CategoryEntityId",
                table: "AdvtEntity",
                column: "CategoryEntityId",
                principalTable: "CategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtReviewEntity_AdvtEntity_AdvtId",
                table: "AdvtReviewEntity",
                column: "AdvtId",
                principalTable: "AdvtEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtReviewEntity_UserEntity_AuthorId",
                table: "AdvtReviewEntity",
                column: "AuthorId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId1",
                table: "CategoryEntity",
                column: "ParentCategoryId1",
                principalTable: "CategoryEntity",
                principalColumn: "Id");
        }
    }
}
