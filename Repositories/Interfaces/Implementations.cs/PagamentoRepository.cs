namespace Projeto_PetShop.Repositories.Implementations;

using Projeto_PetShop.Models;
using Projeto_PetShop.Repositories.Interfaces;
using Projeto_PetShop.Data;
using Microsoft.EntityFrameworkCore;

public class PagamentoRepository : IPagamentoRepository
{
    private readonly AppDBContext _context;

    public PagamentoRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<Pagamento> CreateAsync(Pagamento pagamento)
    {
        await _context.Pagamentos.AddAsync(pagamento);
        await _context.SaveChangesAsync();
        return pagamento;
    }

    public async Task<Pagamento?> GetByIdAsync(int id)
    {
        return await _context.Pagamentos
       .Include(p => p.Agendamento)
           .ThenInclude(a => a.Pet)
       .Include(p => p.Agendamento)
           .ThenInclude(a => a.Servico)
       .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Pagamento>> GetAllAsync()
    {
        return await _context.Pagamentos
    .Include(p => p.Agendamento)
        .ThenInclude(a => a.Pet)
    .Include(p => p.Agendamento)
        .ThenInclude(a => a.Servico)
    .ToListAsync();
    }

    public async Task<Pagamento> UpdateAsync(Pagamento pagamento)
    {
        var pagamentoExistente = await _context.Pagamentos
            .FirstOrDefaultAsync(p => p.Id == pagamento.Id);

        if (pagamentoExistente == null)
        {
            return null;
        }

        pagamentoExistente.Valor = pagamento.Valor;
        pagamentoExistente.MetodoPagamento = pagamento.MetodoPagamento;
        pagamentoExistente.DataPagamento = pagamento.DataPagamento;
        pagamentoExistente.AgendamentoId = pagamento.AgendamentoId;

        await _context.SaveChangesAsync();
        return pagamentoExistente;
    }

    public async Task<bool> DeleteAsync(Pagamento pagamento)
    {
        _context.Pagamentos.Remove(pagamento);
        await _context.SaveChangesAsync();
        return true;
    }
}
