namespace Projeto_PetShop.Service.Interface;

using Projeto_PetShop.Aplication.ServiceResult;
using Projeto_PetShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface ITutorService
{
    Task<ServiceResult<Tutor>> CreateAsync(Tutor tutor);
    Task<Tutor?> GetByIdAsync(int id);
    Task<IEnumerable<Tutor>> GetAllAsync();
    Task<ServiceResult<Tutor>> UpdateAsync(Tutor tutor);
    Task<ServiceResult<bool>> DeleteAsync(int id);
}