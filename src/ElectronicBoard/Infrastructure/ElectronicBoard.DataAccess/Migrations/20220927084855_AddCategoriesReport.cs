using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class AddCategoriesReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId",
                table: "CategoryEntity");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "CategoryEntity",
                newName: "ParentCategoryId1");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEntity_ParentCategoryId",
                table: "CategoryEntity",
                newName: "IX_CategoryEntity_ParentCategoryId1");

            migrationBuilder.CreateTable(
                name: "CategoriesReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesReport", x => x.Id);
                });

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
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId1",
                table: "CategoryEntity");

            migrationBuilder.DropTable(
                name: "CategoriesReport");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId1",
                table: "CategoryEntity",
                newName: "ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEntity_ParentCategoryId1",
                table: "CategoryEntity",
                newName: "IX_CategoryEntity_ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEntity_CategoryEntity_ParentCategoryId",
                table: "CategoryEntity",
                column: "ParentCategoryId",
                principalTable: "CategoryEntity",
                principalColumn: "Id");
        }
    }
}
