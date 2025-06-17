namespace Projeto_PetShop.Models;

using Projeto_PetShop.Aplication.ServiceResult;
using Projeto_PetShop.Enums.Agendamento;
using System.ComponentModel.DataAnnotations;

public class Agendamento
{
    public int Id { get; set; }
    public DateTime DataHoraAgendamento { get; set; }

    [Required(ErrorMessage = "A data do agendamento é obrigatória.")]
    [Display(Name = "Data do Atendimento")]
    public DateTime DataHoraAtendimento { get; set; }

    public int PetId { get; set; } // Chave estrangeira do Pet.
    public Pet? Pet { get; set; } // Navegação para acessar os dados do Pet.

    public int ServicoId { get; set; } // Chave estrangeira de Serviço
    public Servico? Servico { get; set; } //Navegação de Serviço

    [Required(ErrorMessage = "O status do agendamento é obrigatório.")]
    public StatusAgendamento status { get; set; }
}
