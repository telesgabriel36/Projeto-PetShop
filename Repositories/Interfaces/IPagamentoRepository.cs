namespace Projeto_PetShop.Repositories.Interfaces;

using Projeto_PetShop.Models;

public interface IPagamentoRepository
{
    Task<Pagamento> CreateAsync(Pagamento pagamento);
    Task<Pagamento?> GetByIdAsync(int id);
    Task<IEnumerable<Pagamento>> GetAllAsync();
    Task<Pagamento> UpdateAsync(Pagamento pagamento);
    Task<bool> DeleteAsync(Pagamento pagamento);
}