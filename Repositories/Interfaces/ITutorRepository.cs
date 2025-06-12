namespace Projeto_PetShop.Repositories.Interfaces;

using Projeto_PetShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetAllAsync();
    Task<Tutor?> GetByIdAsync(int id);
    Task<Tutor> CreateAsync(Tutor tutor);
    Task<Tutor> UpdateAsync(Tutor tutor);
    Task<bool> DeleteAsync(Tutor tutor);
}