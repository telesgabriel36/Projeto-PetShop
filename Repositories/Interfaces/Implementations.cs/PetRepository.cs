namespace Projeto_PetShop.Repositories.Implementations;

using Projeto_PetShop.Models;
using Projeto_PetShop.Repositories.Interfaces;
using Projeto_PetShop.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class PetRepository : IPetRepository
{
    private readonly AppDBContext _context;
    public PetRepository(AppDBContext context)
    {
        _context = context;
    }

    //Criação do Pet
    public async Task<Pet> CreateAsync(Pet pet)
    {
        await _context.Pets.AddAsync(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    //Remoção do Pet
    public async Task<bool> DeleteAsync(Pet pet)
    {
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
        return true; // Retorna verdadeiro se a exclusão for bem-sucedida 
    }

    //Lista de Pets
    public async Task<IEnumerable<Pet>> GetAllAsync()
    {
        return await _context.Pets.Include(p => p.Tutor).ToListAsync();
    }

    //Busca de Pets
    public async Task<Pet?> GetByIdAsync(int id)
    {
        return await _context.Pets.Include(p => p.Tutor)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    //Atualização de Pets
    public async Task<Pet> UpdateAsync(Pet pet)
    {
        var petExiste = await _context.Pets.FirstOrDefaultAsync(petDB => petDB.Id == pet.Id);
        if (petExiste == null)
        {
            return null; // Retorna nulo se o tutor não for encontrado
        }
        petExiste.Nome = pet.Nome;
        petExiste.Especie = pet.Especie;
        petExiste.Raca = pet.Raca;
        petExiste.DataNascimento = pet.DataNascimento;
        petExiste.TutorId = pet.TutorId;
        await _context.SaveChangesAsync();
        return petExiste;

    }
}
