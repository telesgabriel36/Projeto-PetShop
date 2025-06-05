namespace Projeto_PetShop.Models;

public class Agendamento
{
    public int Id { get; set; }
    public DateTime DataHoraAgendamento { get; set; }
    public DateTime DataHoraAtendimento { get; set; }

    public int IdPet { get; set; } // Chave estrangeira do Pet.
    public Pet Pet { get; set; } = null!;// Navegação para acessar os dados do Pet.

    public List<AgendamentoServico> AgendamentoServicos { get; set; } = new(); // Lista de serviços associados ao agendamento.

}