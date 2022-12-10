using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class _2_EditPhotosInAdvt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base64Str",
                table: "Photos");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Photos",
                type: "bytea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "Base64Str",
                table: "Photos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
