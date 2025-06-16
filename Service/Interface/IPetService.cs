namespace Projeto_PetShop.Service.Interface;

using Projeto_PetShop.Aplication.ServiceResult;
using Projeto_PetShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IPetService
{
    Task<ServiceResult<Pet>> CreateAsync(Pet pet);
    Task<ServiceResult<Pet?>> GetByIdAsync(int id);
    Task<IEnumerable<Pet>> GetAllAsync();
    Task<ServiceResult<Pet>> UpdateAsync(Pet pet);
    Task<ServiceResult<bool>> DeleteAsync(int id);
}