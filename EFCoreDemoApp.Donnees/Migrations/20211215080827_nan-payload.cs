using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDemoApp.Donnees.Migrations
{
    public partial class nanpayload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActeurFilm_Acteurs_ActeursId",
                table: "ActeurFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_ActeurFilm_Films_FilmsId",
                table: "ActeurFilm");

            migrationBuilder.RenameColumn(
                name: "FilmsId",
                table: "ActeurFilm",
                newName: "FilmId");

            migrationBuilder.RenameColumn(
                name: "ActeursId",
                table: "ActeurFilm",
                newName: "ActeurId");

            migrationBuilder.RenameIndex(
                name: "IX_ActeurFilm_FilmsId",
                table: "ActeurFilm",
                newName: "IX_ActeurFilm_FilmId");

            migrationBuilder.AddColumn<int>(
                name: "MinutesALEcran",
                table: "ActeurFilm",
                type: "int",
                nullable: false,
                defaultValue: 10);

            migrationBuilder.AddForeignKey(
                name: "FK_ActeurFilm_Acteurs_ActeurId",
                table: "ActeurFilm",
                column: "ActeurId",
                principalTable: "Acteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActeurFilm_Films_FilmId",
                table: "ActeurFilm",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActeurFilm_Acteurs_ActeurId",
                table: "ActeurFilm");

            migrationBuilder.DropForeignKey(
                name: "FK_ActeurFilm_Films_FilmId",
                table: "ActeurFilm");

            migrationBuilder.DropColumn(
                name: "MinutesALEcran",
                table: "ActeurFilm");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "ActeurFilm",
                newName: "FilmsId");

            migrationBuilder.RenameColumn(
                name: "ActeurId",
                table: "ActeurFilm",
                newName: "ActeursId");

            migrationBuilder.RenameIndex(
                name: "IX_ActeurFilm_FilmId",
                table: "ActeurFilm",
                newName: "IX_ActeurFilm_FilmsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActeurFilm_Acteurs_ActeursId",
                table: "ActeurFilm",
                column: "ActeursId",
                principalTable: "Acteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActeurFilm_Films_FilmsId",
                table: "ActeurFilm",
                column: "FilmsId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
