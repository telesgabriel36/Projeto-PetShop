namespace Projeto_PetShop.Repositories.Interfaces;

using Projeto_PetShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IServicoRepository
{
    Task<IEnumerable<Servico>> GetAllAsync();
    Task<Servico?> GetByIdAsync(int id);
    Task<Servico> CreateAsync(Servico servico);
    Task<Servico> UpdateAsync(Servico servico);
    Task<bool> DeleteAsync(Servico servico);

}