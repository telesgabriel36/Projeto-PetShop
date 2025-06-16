using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_PetShop.Migrations
{
    /// <inheritdoc />
    public partial class RenameandoIdTutorToTutorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTutor",
                table: "Pets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTutor",
                table: "Pets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
