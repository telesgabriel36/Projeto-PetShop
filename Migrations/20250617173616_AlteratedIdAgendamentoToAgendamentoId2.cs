using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_PetShop.Migrations
{
    /// <inheritdoc />
    public partial class AlteratedIdAgendamentoToAgendamentoId2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Agendamentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Agendamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
