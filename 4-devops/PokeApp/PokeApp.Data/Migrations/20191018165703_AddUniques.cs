using Microsoft.EntityFrameworkCore.Migrations;

namespace PokeApp.Data.Migrations
{
    public partial class AddUniques : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PokemonType_Name",
                table: "PokemonType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_Name",
                table: "Pokemon",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PokemonType_Name",
                table: "PokemonType");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_Name",
                table: "Pokemon");
        }
    }
}
