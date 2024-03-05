using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPianoApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    Album = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreSong",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "integer", nullable: false),
                    SongsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreSong", x => new { x.GenresId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_GenreSong_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Electro" },
                    { 2, "Indie" },
                    { 3, "Grime" },
                    { 4, "Pop" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Age", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, 48, "Mathangi \"Maya\" Arulpragasam (born 18 July 1975 in Hounslow, London) is an artist, movie graduate and musician. She is the daughter of a Tamil revolutionary. She is best known by her stage name M.I.A. Her music style contains elements of grime, alternative, hip-hop, dance, and electronic music.", "M.I.A." },
                    { 2, 25, "Jordan Kelley and Jason Huber met at Nashville's water park Nashville Shores whilst riding boogie boards in the wave pool. Kelley and Huber both attended Middle Tennessee State University and studied music tech. Jordan Kelley is originally from Lincoln Nebraska.", "Cherub" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "ArtistId", "Length", "Title" },
                values: new object[,]
                {
                    { 1, "Kala", 1, 3.2f, "Paper Plans" },
                    { 2, "Matangi", 1, 3.5f, "Bad Girls" },
                    { 3, "Year of the Caprese", 2, 3.8f, "Doses and Mimosas" },
                    { 4, "DJ BJ's Faves", 2, 4.5f, "Who Knows" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreSong_SongsId",
                table: "GenreSong",
                column: "SongsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreSong");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
