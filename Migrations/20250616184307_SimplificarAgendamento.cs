using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_PetShop.Migrations
{
    /// <inheritdoc />
    public partial class SimplificarAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendamentoServicos");

            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "Agendamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ServicoId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Agendamentos");

            migrationBuilder.CreateTable(
                name: "AgendamentoServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AgendamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    IdAgendamento = table.Column<int>(type: "INTEGER", nullable: false),
                    IdServico = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendamentoServicos_Agendamentos_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Agendamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentoServicos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoServicos_AgendamentoId",
                table: "AgendamentoServicos",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoServicos_ServicoId",
                table: "AgendamentoServicos",
                column: "ServicoId");
        }
    }
}
