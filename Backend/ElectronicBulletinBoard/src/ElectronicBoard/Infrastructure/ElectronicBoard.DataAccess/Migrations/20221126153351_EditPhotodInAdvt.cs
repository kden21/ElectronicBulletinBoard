using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class EditPhotodInAdvt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Advts");

            migrationBuilder.AddColumn<int>(
                name: "AdvtId",
                table: "Photos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AdvtId",
                table: "Photos",
                column: "AdvtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Advts_AdvtId",
                table: "Photos",
                column: "AdvtId",
                principalTable: "Advts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Advts_AdvtId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_AdvtId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AdvtId",
                table: "Photos");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Advts",
                type: "bytea",
                nullable: true);
        }
    }
}
