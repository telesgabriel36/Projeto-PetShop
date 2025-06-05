namespace Projeto_PetShop.Models;

public class Tutor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;

    public List<Pet> Pets { get; set; } = new();// Lista de Pets associados ao Tutor.
}