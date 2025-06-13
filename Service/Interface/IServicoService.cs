namespace Projeto_PetShop.Service.Interface;

using Projeto_PetShop.Aplication.ServiceResult;
using Projeto_PetShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IServicoService
{
    Task<ServiceResult<Servico>> CreateAsync(Servico servico);
    Task<ServiceResult<Servico?>> GetByIdAsync(int id);
    Task<IEnumerable<Servico>> GetAllAsync();
    Task<ServiceResult<Servico>> UpdateAsync(Servico servico);
    Task<ServiceResult<bool>> DeleteAsync(int id);
}