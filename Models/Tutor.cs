using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_PetShop.Models;

public class Tutor
{

    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do tutor é obrigatório.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "O nome deve ter entre 6 e 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O número é obrigatório.")]
    [Phone(ErrorMessage = "Formato de telefone inválido.")]
    [StringLength(11, MinimumLength = 10, ErrorMessage = "O número deve ter entre 10 e 11 dígitos.")]
    [DisplayFormat(DataFormatString = "{0:(##) #####-####}", ApplyFormatInEditMode = true)]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O endereço é obrigatório.")]
    public string Endereco { get; set; } = string.Empty;

    public List<Pet> Pets { get; set; } = new();// Lista de Pets associados ao Tutor.
}