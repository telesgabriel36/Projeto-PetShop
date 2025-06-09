namespace Projeto_PetShop.Service.Interface;

using Projeto_PetShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface ITutorService
{
    Task<Tutor> CreateAsync(Tutor tutor);
    Task<Tutor?> GetByIdAsync(int id);
    Task<IEnumerable<Tutor>> GetAllAsync();
    Task<Tutor> UpdateAsync(Tutor tutor);
    Task<bool> DeleteAsync(int id);
}