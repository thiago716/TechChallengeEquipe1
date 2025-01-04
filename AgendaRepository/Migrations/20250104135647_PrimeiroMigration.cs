using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Dados.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiroMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_AGENDA",
                columns: table => new
                {
                    ID_CONTATO = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    TELEFONE = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    CELULAR = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    EMAIL = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DDD = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_AGENDA", x => x.ID_CONTATO);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_AGENDA_DDD",
                table: "TB_AGENDA",
                column: "DDD");

            migrationBuilder.CreateIndex(
                name: "IX_TB_AGENDA_EMAIL",
                table: "TB_AGENDA",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_AGENDA");
        }
    }
}
