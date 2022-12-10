using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicBoard.DataAccess.Migrations
{
    public partial class AddFavoriteAdvtsInUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvtEntityUserEntity",
                columns: table => new
                {
                    FavoriteAdvtsId = table.Column<int>(type: "integer", nullable: false),
                    UsersVotersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvtEntityUserEntity", x => new { x.FavoriteAdvtsId, x.UsersVotersId });
                    table.ForeignKey(
                        name: "FK_AdvtEntityUserEntity_Advts_FavoriteAdvtsId",
                        column: x => x.FavoriteAdvtsId,
                        principalTable: "Advts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvtEntityUserEntity_Users_UsersVotersId",
                        column: x => x.UsersVotersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvtEntityUserEntity_UsersVotersId",
                table: "AdvtEntityUserEntity",
                column: "UsersVotersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvtEntityUserEntity");
        }
    }
}
