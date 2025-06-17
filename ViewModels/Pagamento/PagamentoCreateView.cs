namespace Projeto_PetShop.ViewModels;

using System.Collections.Generic;

using Projeto_PetShop.Models;

public class PagamentoCreateViewModel
{
    public Agendamento Agendamento { get; set; } = new Agendamento();
    public Pagamento Pagamento { get; set; } = new Pagamento();
}