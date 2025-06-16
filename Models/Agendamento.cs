namespace Projeto_PetShop.Models;

public class Agendamento
{
    public int Id { get; set; }
    public DateTime DataHoraAgendamento { get; set; }
    public DateTime DataHoraAtendimento { get; set; }

    public int PetId { get; set; } // Chave estrangeira do Pet.
    public Pet? Pet { get; set; } // Navegação para acessar os dados do Pet.

    public int ServicoId { get; set; } // Chave estrangeira de Serviço
    public Servico? Servico { get; set; } //Navegação de Serviço

}
