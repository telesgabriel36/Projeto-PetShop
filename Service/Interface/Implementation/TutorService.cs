namespace Projeto_PetShop.Service.Implementation;

using Projeto_PetShop.Models;
using Projeto_PetShop.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto_PetShop.Repositories.Interfaces;

public class TutorService : ITutorService
{
    private readonly ITutorRepository _tutorRepository; // Variavel de injeção

    public TutorService(ITutorRepository tutorRepository) // Injeção de dependência do repositório
    {
        _tutorRepository = tutorRepository;
    }

    public async Task<Tutor> CreateAsync(Tutor tutor)
    {
        if (tutor == null)
        {
            Console.WriteLine("ERROER(TUTORSERVICE): O tutor não pode ser nulo.");
            return null;
        }
        return await _tutorRepository.CreateAsync(tutor);
    }

    public async Task<Tutor?> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            Console.WriteLine($" ERROR(TUTORSERVICE): Tutor {id} não encontrado.");
            return null;
        }
        return await _tutorRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Tutor>> GetAllAsync()
    {
        return await _tutorRepository.GetAllAsync();
    }

    public async Task<Tutor> UpdateAsync(Tutor tutor)
    {
        if (tutor == null)
        {
            Console.WriteLine("ERROR(TUTORSERVICE): O tutor não pode ser nulo.");
            return null;
        }

        var tutorExiste = await _tutorRepository.GetByIdAsync(tutor.Id);
        if (tutorExiste == null)
        {
            Console.WriteLine($"ERROR(TUTORSERVICE): Tutor {tutor.Id} não encontrado para atualização.");
            return null;
        }

        return await _tutorRepository.UpdateAsync(tutor);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tutorExiste = await GetByIdAsync(id);
        if (tutorExiste == null)
        {
            Console.WriteLine($"ERROR(TUTORSERVICE): Tutor {id} não foi encontrado.");
            return false;
        }
        return await _tutorRepository.DeleteAsync(id);
    }
}