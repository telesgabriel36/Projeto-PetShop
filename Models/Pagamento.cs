namespace Projeto_PetShop.Models;

public class Pagamento
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataPagamento { get; set; }
    public string MetodoPagamento { get; set; } = string.Empty; // Método de pagamento utilizado (ex: Cartão, Dinheiro, Pix).
    
    public int AgendamentoId { get; set; } // Chave estrangeira do Agendamento.
    public Agendamento ?Agendamento { get; set; } // Navegação para acessar os dados do Agendamento.
}