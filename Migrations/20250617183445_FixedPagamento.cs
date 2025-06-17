using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_PetShop.Migrations
{
    /// <inheritdoc />
    public partial class FixedPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAgendamento",
                table: "Pagamentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAgendamento",
                table: "Pagamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
