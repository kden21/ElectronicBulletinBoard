using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class _4_UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvtEntity_CategoryEntity_CategoryId",
                table: "AdvtEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvtEntity_UserEntity_UserId",
                table: "AdvtEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReviews_AdvtEntity_AdvtId",
                table: "AdvtReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReviews_UserEntity_AuthorId",
                table: "AdvtReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId1",
                table: "CategoryEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_UserEntity_AuthorId",
                table: "UserReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_UserEntity_UserId",
                table: "UserReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryEntity",
                table: "CategoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvtEntity",
                table: "AdvtEntity");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "CategoryEntity",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "AdvtEntity",
                newName: "Advts");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEntity_ParentCategoryId1",
                table: "Categories",
                newName: "IX_Categories_ParentCategoryId1");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtEntity_UserId",
                table: "Advts",
                newName: "IX_Advts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtEntity_CategoryId",
                table: "Advts",
                newName: "IX_Advts_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advts",
                table: "Advts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtReviews_Advts_AdvtId",
                table: "AdvtReviews",
                column: "AdvtId",
                principalTable: "Advts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtReviews_Users_AuthorId",
                table: "AdvtReviews",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advts_Categories_CategoryId",
                table: "Advts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advts_Users_UserId",
                table: "Advts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId1",
                table: "Categories",
                column: "ParentCategoryId1",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Users_AuthorId",
                table: "UserReviews",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Users_UserId",
                table: "UserReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReviews_Advts_AdvtId",
                table: "AdvtReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvtReviews_Users_AuthorId",
                table: "AdvtReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Advts_Categories_CategoryId",
                table: "Advts");

            migrationBuilder.DropForeignKey(
                name: "FK_Advts_Users_UserId",
                table: "Advts");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId1",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Users_AuthorId",
                table: "UserReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Users_UserId",
                table: "UserReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advts",
                table: "Advts");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserEntity");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "CategoryEntity");

            migrationBuilder.RenameTable(
                name: "Advts",
                newName: "AdvtEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentCategoryId1",
                table: "CategoryEntity",
                newName: "IX_CategoryEntity_ParentCategoryId1");

            migrationBuilder.RenameIndex(
                name: "IX_Advts_UserId",
                table: "AdvtEntity",
                newName: "IX_AdvtEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Advts_CategoryId",
                table: "AdvtEntity",
                newName: "IX_AdvtEntity_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryEntity",
                table: "CategoryEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvtEntity",
                table: "AdvtEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtEntity_CategoryEntity_CategoryId",
                table: "AdvtEntity",
                column: "CategoryId",
                principalTable: "CategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtEntity_UserEntity_UserId",
                table: "AdvtEntity",
                column: "UserId",
                principalTable: "UserEntity",
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
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId1",
                table: "CategoryEntity",
                column: "ParentCategoryId1",
                principalTable: "CategoryEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_UserEntity_AuthorId",
                table: "UserReviews",
                column: "AuthorId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_UserEntity_UserId",
                table: "UserReviews",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
