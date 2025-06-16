using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_PetShop.Migrations
{
    /// <inheritdoc />
    public partial class RenameIdPetToPetIdInAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPet",
                table: "Agendamentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPet",
                table: "Agendamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
