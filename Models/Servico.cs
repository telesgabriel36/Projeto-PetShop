
using System.ComponentModel.DataAnnotations;
namespace Projeto_PetShop.Models;

public class Servico
{

    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do serviço é obrigatório.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O valor é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    public decimal Valor { get; set; }

}