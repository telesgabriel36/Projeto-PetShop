namespace Projeto_PetShop.Repositories.Implementations;

using Projeto_PetShop.Models;
using Projeto_PetShop.Repositories.Interfaces;
using Projeto_PetShop.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class TutorRepository : ITutorRepository
{
    private readonly AppDBContext _context;

    public TutorRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<Tutor> CreateAsync(Tutor tutor)
    {
        await _context.Tutores.AddAsync(tutor);
        await _context.SaveChangesAsync();
        return tutor;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tutor = await _context.Tutores.FindAsync(id); // Primeiro busca a instância do tutor pelo ID
        if (tutor == null)
        {
            return false; // Retorna falso se o tutor não for encontrado
        }
        _context.Tutores.Remove(tutor);
        await _context.SaveChangesAsync();
        return true; // Retorna verdadeiro se a exclusão for bem-sucedida 
    }

    public async Task<IEnumerable<Tutor>> GetAllAsync()
    {

        return await _context.Tutores.ToListAsync(); // Retorna a lista de tutores
    }

    public async Task<Tutor?> GetByIdAsync(int id)
    {
        var tutor = await _context.Tutores.FindAsync(id); //Buscando o tutor pelo ID
        return tutor; // Retorna o tutor encontrado ou nulo se não existir

    }

    //Verificar a questão de salvar cada campo... Do jeito que está, ele atualiza todos os campos do tutor
    public async Task<Tutor> UpdateAsync(Tutor tutor)
    {
        var tutorExiste = await _context.Tutores.AsNoTracking().FirstOrDefaultAsync(t => t.Id == tutor.Id);
        if (tutorExiste == null)
        {
            return null; // Retorna nulo se o tutor não for encontrado
        }
        _context.Tutores.Update(tutor);
        await _context.SaveChangesAsync();
        return tutor;
    }
}