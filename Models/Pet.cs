using System.ComponentModel.DataAnnotations;
namespace Projeto_PetShop.Models;

public class Pet
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do pet é obrigatório.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 50 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A espécie do pet é obrigatória.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "A espécie deve ter entre 3 e 50 caracteres.")]
    public string Especie { get; set; } = string.Empty;

    [Required(ErrorMessage = "A raça do pet é obrigatório.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "A raça deve ter entre 3 e 50 caracteres.")]
    public string Raca { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DataNascimento { get; set; }

    public int TutorId { get; set; } // Chave estrangeira do Tutor.
    public Tutor ?Tutor { get; set; } // Navegação para acessar os dados do Tutor.
}