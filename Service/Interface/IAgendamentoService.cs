namespace Projeto_PetShop.Service.Interface;

using Projeto_PetShop.Aplication.ServiceResult;
using Projeto_PetShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IAgendamentoService
{
    Task<ServiceResult<Agendamento>> CreateAsync(Agendamento agendamento);
    Task<ServiceResult<Agendamento?>> GetByIdAsync(int id);
    Task<IEnumerable<Agendamento>> GetAllAsync();
    Task<ServiceResult<Agendamento>> UpdateAsync(Agendamento agendamento);
    Task<ServiceResult<bool>> DeleteAsync(int id);
}