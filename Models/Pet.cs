namespace Projeto_PetShop.Models;

public class Pet
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string Raca { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }

    public int IdTutor { get; set; } // Chave estrangeira do Tutor.
    public Tutor Tutor { get; set; } = new();// Navegação para acessar os dados do Tutor.
}