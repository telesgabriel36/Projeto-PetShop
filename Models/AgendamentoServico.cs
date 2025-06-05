namespace Projeto_PetShop.Models;

public class AgendamentoServico
{
    public int Id { get; set; }
    public int IdAgendamento { get; set; } // Chave estrangeira do Agendamento.
    public Agendamento Agendamento { get; set; } = null!;// Navegação para acessar os dados do Agendamento.

    public int IdServico { get; set; } // Chave estrangeira do Serviço.
    public Servico Servico { get; set; } = null!;// Navegação para acessar os dados do Serviço.

    public decimal ValorTotal { get; set; } // Valor total do Serviço.
}
