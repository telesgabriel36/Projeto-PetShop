namespace Projeto_PetShop.Repositories.Interfaces;

using Projeto_PetShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAgendamentoRepository
{
    Task<IEnumerable<Agendamento>> GetAllAsync();
    Task<Agendamento?> GetByIdAsync(int id);
    Task<Agendamento> CreateAsync(Agendamento agendamento);
    Task<Agendamento> UpdateAsync(Agendamento agendamento);
    Task<bool> DeleteAsync(Agendamento agendamento);
}