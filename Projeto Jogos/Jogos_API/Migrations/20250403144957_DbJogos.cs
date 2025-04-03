using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jogos_API.Migrations
{
    /// <inheritdoc />
    public partial class DbJogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogo",
                columns: table => new
                {
                    JogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    NickName = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.JogoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeDoJogo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Plataforma = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    JogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Jogo_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogo",
                        principalColumn: "JogoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_Nome",
                table: "Jogo",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_JogoId",
                table: "Usuario",
                column: "JogoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Jogo");
        }
    }
}
