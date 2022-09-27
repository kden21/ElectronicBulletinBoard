using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class _1_UserReview : Migration
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
                name: "UserId",
                table: "AdvtEntity",
                newName: "UserEntityId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "AdvtEntity",
                newName: "CategoryEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtEntity_UserId",
                table: "AdvtEntity",
                newName: "IX_AdvtEntity_UserEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtEntity_CategoryId",
                table: "AdvtEntity",
                newName: "IX_AdvtEntity_CategoryEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "UserEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "UserEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CategoryEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "AdvtEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AdvtEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "AdvtReviewEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdvtEntityId = table.Column<int>(type: "integer", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvtReviewEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvtReviewEntity_AdvtEntity_AdvtEntityId",
                        column: x => x.AdvtEntityId,
                        principalTable: "AdvtEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserEntityId = table.Column<int>(type: "integer", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReviews_UserEntity_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "UserEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvtReviewEntity_AdvtEntityId",
                table: "AdvtReviewEntity",
                column: "AdvtEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_UserEntityId",
                table: "UserReviews",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtEntity_CategoryEntity_CategoryEntityId",
                table: "AdvtEntity",
                column: "CategoryEntityId",
                principalTable: "CategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvtEntity_UserEntity_UserEntityId",
                table: "AdvtEntity",
                column: "UserEntityId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryEntityId1",
                table: "CategoryEntity",
                column: "ParentCategoryEntityId1",
                principalTable: "CategoryEntity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvtEntity_CategoryEntity_CategoryEntityId",
                table: "AdvtEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvtEntity_UserEntity_UserEntityId",
                table: "AdvtEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryEntityId1",
                table: "CategoryEntity");

            migrationBuilder.DropTable(
                name: "AdvtReviewEntity");

            migrationBuilder.DropTable(
                name: "UserReviews");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryEntityId1",
                table: "CategoryEntity",
                newName: "ParentCategoryId1");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEntity_ParentCategoryEntityId1",
                table: "CategoryEntity",
                newName: "IX_CategoryEntity_ParentCategoryId1");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "AdvtEntity",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CategoryEntityId",
                table: "AdvtEntity",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtEntity_UserEntityId",
                table: "AdvtEntity",
                newName: "IX_AdvtEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvtEntity_CategoryEntityId",
                table: "AdvtEntity",
                newName: "IX_AdvtEntity_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "UserEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "UserEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CategoryEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "AdvtEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AdvtEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId1",
                table: "CategoryEntity",
                column: "ParentCategoryId1",
                principalTable: "CategoryEntity",
                principalColumn: "Id");
        }
    }
}
