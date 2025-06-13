namespace Projeto_PetShop.Repositories.Implementations;

using Projeto_PetShop.Models;
using Projeto_PetShop.Data;
using Projeto_PetShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ServicoRepository : IServicoRepository
{
    private AppDBContext _context;
    public ServicoRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<Servico> CreateAsync(Servico servico)
    {
        await _context.Servicos.AddAsync(servico);
        await _context.SaveChangesAsync();
        return servico;
    }

    public async Task<bool> DeleteAsync(Servico servico)
    {
        _context.Servicos.Remove(servico);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Servico>> GetAllAsync()
    {
        var listaServicos = await _context.Servicos.ToListAsync();
        return listaServicos;
    }

    public async Task<Servico?> GetByIdAsync(int id)
    {
        return await _context.Servicos.FindAsync(id);
    }

    public async Task<Servico> UpdateAsync(Servico servico)
    {
        var servicoExiste = await _context.Servicos.FirstOrDefaultAsync(servicoBd => servicoBd.Id == servico.Id);
        if (servicoExiste == null)
        {
            return null;
        }
        servicoExiste.Nome = servico.Nome;
        servicoExiste.Valor = servico.Valor;
        await _context.SaveChangesAsync();
        return servicoExiste;
    }
}