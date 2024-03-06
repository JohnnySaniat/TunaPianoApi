using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunaPianoApi.Migrations
{
    public partial class JCSDTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId1",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_ArtistId1",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "ArtistId1",
                table: "Songs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId1",
                table: "Songs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId1",
                table: "Songs",
                column: "ArtistId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistId1",
                table: "Songs",
                column: "ArtistId1",
                principalTable: "Artists",
                principalColumn: "Id");
        }
    }
}
