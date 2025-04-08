using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jogos_API.Migrations
{
    /// <inheritdoc />
    public partial class InicialCriate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Jogo_Nome",
                table: "Jogo");

            migrationBuilder.DropColumn(
                name: "NomeDoJogo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Plataforma",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "Jogo");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Jogo");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "Usuario",
                type: "VARCHAR(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Usuario",
                type: "VARCHAR(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeDoJogo",
                table: "Jogo",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plataforma",
                table: "Jogo",
                type: "VARCHAR(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_NomeDoJogo",
                table: "Jogo",
                column: "NomeDoJogo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Jogo_NomeDoJogo",
                table: "Jogo");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "NomeDoJogo",
                table: "Jogo");

            migrationBuilder.DropColumn(
                name: "Plataforma",
                table: "Jogo");

            migrationBuilder.AddColumn<string>(
                name: "NomeDoJogo",
                table: "Usuario",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plataforma",
                table: "Usuario",
                type: "VARCHAR(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "Jogo",
                type: "VARCHAR(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Jogo",
                type: "VARCHAR(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_Nome",
                table: "Jogo",
                column: "Nome",
                unique: true);
        }
    }
}
