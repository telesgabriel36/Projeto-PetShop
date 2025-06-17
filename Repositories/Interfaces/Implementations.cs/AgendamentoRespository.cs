namespace Projeto_PetShop.Repositories.Implementations;

using Projeto_PetShop.Models;
using Projeto_PetShop.Repositories.Interfaces;
using Projeto_PetShop.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class AgendamentoRepository : IAgendamentoRepository
{
    private readonly AppDBContext _context;

    public AgendamentoRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<Agendamento> CreateAsync(Agendamento agendamento)
    {
        await _context.Agendamentos.AddAsync(agendamento);
        await _context.SaveChangesAsync();
        return agendamento;
    }

    public async Task<bool> DeleteAsync(Agendamento agendamento)
    {
        _context.Agendamentos.Remove(agendamento);
        await _context.SaveChangesAsync();
        return true; // Retorna verdadeiro se a exclusão for bem-sucedida 
    }

    public async Task<IEnumerable<Agendamento>> GetAllAsync()
    {
        return await _context.Agendamentos
       .Include(a => a.Pet)
       .Include(a => a.Servico)
       .ToListAsync();
    }

    public async Task<Agendamento?> GetByIdAsync(int id)
    {
        return await _context.Agendamentos
        .Include(a => a.Pet)
        .Include(a => a.Servico)
        .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Agendamento> UpdateAsync(Agendamento agendamento)
    {
        var agendamentoExiste = await _context.Agendamentos.FirstOrDefaultAsync(ag => ag.Id == agendamento.Id);
        if (agendamentoExiste == null)
        {
            return null; // Retorna nulo se o tutor não for encontrado
        }
        agendamentoExiste.DataHoraAtendimento = agendamento.DataHoraAtendimento;
        agendamentoExiste.ServicoId = agendamento.ServicoId;
        agendamentoExiste.PetId = agendamento.PetId;
        agendamentoExiste.status = agendamento.status;
        await _context.SaveChangesAsync();
        return agendamentoExiste;
    }
}
