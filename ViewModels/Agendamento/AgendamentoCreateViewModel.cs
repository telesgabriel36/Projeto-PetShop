namespace Projeto_PetShop.ViewModels;

using System.Collections.Generic;

using Projeto_PetShop.Models;

public class AgendamentoCreateViewModel
{
    public Agendamento Agendamento { get; set; } = new Agendamento();
    public IEnumerable<Pet> Pets { get; set; } = new List<Pet>();
    public IEnumerable<Servico> Servicos { get; set; } = new List<Servico>();
}