using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class _1_UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvtEntity_UserEntity_UserEntityId",
                table: "AdvtEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReviewEntity_AdvtEntity_AdvtEntityId",
                table: "AdvtReviewEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryEntityId1",
                table: "CategoryEntity");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryEntityId1",
                table: "CategoryEntity",
                newName: "ParentCategoryId1");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEntity_ParentCategoryEntityId1",
                table: "CategoryEntity",
                newName: "IX_CategoryEntity_ParentCategoryId1");

            migrationBuilder.RenameColumn(
                name: "AdvtEntityId",
                table: "AdvtReviewEntity",
                newName: "AdvtId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtReviewEntity_AdvtEntityId",
                table: "AdvtReviewEntity",
                newName: "IX_AdvtReviewEntity_AdvtId");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "AdvtEntity",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtEntity_UserEntityId",
                table: "AdvtEntity",
                newName: "IX_AdvtEntity_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtEntity_UserEntity_UserId",
                table: "AdvtEntity",
                column: "UserId",
                principalTable: "UserEntity",
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
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId1",
                table: "CategoryEntity",
                column: "ParentCategoryId1",
                principalTable: "CategoryEntity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvtEntity_UserEntity_UserId",
                table: "AdvtEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReviewEntity_AdvtEntity_AdvtId",
                table: "AdvtReviewEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId1",
                table: "CategoryEntity");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId1",
                table: "CategoryEntity",
                newName: "ParentCategoryEntityId1");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEntity_ParentCategoryId1",
                table: "CategoryEntity",
                newName: "IX_CategoryEntity_ParentCategoryEntityId1");

            migrationBuilder.RenameColumn(
                name: "AdvtId",
                table: "AdvtReviewEntity",
                newName: "AdvtEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtReviewEntity_AdvtId",
                table: "AdvtReviewEntity",
                newName: "IX_AdvtReviewEntity_AdvtEntityId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AdvtEntity",
                newName: "UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtEntity_UserId",
                table: "AdvtEntity",
                newName: "IX_AdvtEntity_UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtEntity_UserEntity_UserEntityId",
                table: "AdvtEntity",
                column: "UserEntityId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtReviewEntity_AdvtEntity_AdvtEntityId",
                table: "AdvtReviewEntity",
                column: "AdvtEntityId",
                principalTable: "AdvtEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryEntityId1",
                table: "CategoryEntity",
                column: "ParentCategoryEntityId1",
                principalTable: "CategoryEntity",
                principalColumn: "Id");
        }
    }
}
