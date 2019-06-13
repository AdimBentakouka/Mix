using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Videotheque.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(nullable: true),
                    Date_Creation = table.Column<DateTime>(nullable: false),
                    Note = table.Column<int>(nullable: false),
                    Commentaire = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    Age_Minimum = table.Column<int>(nullable: false),
                    AudioDescription = table.Column<bool>(nullable: false),
                    Support_Physique = table.Column<bool>(nullable: false),
                    Support_Mumerique = table.Column<bool>(nullable: false),
                    Statut = table.Column<int>(nullable: false),
                    Langue_VO = table.Column<int>(nullable: false),
                    Langue_Media = table.Column<int>(nullable: false),
                    Sous_Titre = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Duree = table.Column<TimeSpan>(nullable: true),
                    Serie_Duree = table.Column<int>(nullable: true),
                    Nb_Saisons = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediasGenres",
                columns: table => new
                {
                    Id_Genre = table.Column<int>(nullable: false),
                    Id_Media = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediasGenres", x => new { x.Id_Media, x.Id_Genre });
                    table.ForeignKey(
                        name: "FK_MediasGenres_Genres_Id_Genre",
                        column: x => x.Id_Genre,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediasGenres_Medias_Id_Media",
                        column: x => x.Id_Media,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediasGenres_Id_Genre",
                table: "MediasGenres",
                column: "Id_Genre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediasGenres");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Medias");
        }
    }
}
