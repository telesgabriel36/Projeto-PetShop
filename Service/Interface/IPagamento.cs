namespace Projeto_PetShop.Service.Interface;

using Projeto_PetShop.Aplication.ServiceResult;
using Projeto_PetShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IPagamentoService
{
    Task<ServiceResult<Pagamento>> CreateAsync(Pagamento pagamento);
    Task<ServiceResult<Pagamento?>> GetByIdAsync(int id);
    Task<IEnumerable<Pagamento>> GetAllAsync();
    Task<ServiceResult<Pagamento>> UpdateAsync(Pagamento pagamento);
    Task<ServiceResult<bool>> DeleteAsync(int id);
}