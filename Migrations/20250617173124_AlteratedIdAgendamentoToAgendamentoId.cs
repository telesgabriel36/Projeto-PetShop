using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_PetShop.Migrations
{
    /// <inheritdoc />
    public partial class AlteratedIdAgendamentoToAgendamentoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAgendamento",
                table: "Pagamentos");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Agendamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Agendamentos");

            migrationBuilder.AddColumn<int>(
                name: "IdAgendamento",
                table: "Pagamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
