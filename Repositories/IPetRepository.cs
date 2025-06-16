namespace Projeto_PetShop.Repositories.Interfaces;

using Projeto_PetShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetAllAsync();
    Task<Pet?> GetByIdAsync(int id);
    Task<Pet> CreateAsync(Pet pet);
    Task<Pet> UpdateAsync(Pet pet);
    Task<bool> DeleteAsync(Pet pet);
}