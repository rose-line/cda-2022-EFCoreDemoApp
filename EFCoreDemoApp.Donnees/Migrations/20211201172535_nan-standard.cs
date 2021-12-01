using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDemoApp.Donnees.Migrations
{
    public partial class nanstandard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActeurFilm",
                columns: table => new
                {
                    ActeursId = table.Column<int>(type: "int", nullable: false),
                    FilmsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActeurFilm", x => new { x.ActeursId, x.FilmsId });
                    table.ForeignKey(
                        name: "FK_ActeurFilm_Acteurs_ActeursId",
                        column: x => x.ActeursId,
                        principalTable: "Acteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActeurFilm_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActeurFilm_FilmsId",
                table: "ActeurFilm",
                column: "FilmsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActeurFilm");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
