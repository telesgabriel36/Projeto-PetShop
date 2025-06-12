namespace Projeto_PetShop.Service.Implementation;

using Projeto_PetShop.Models;
using Projeto_PetShop.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto_PetShop.Repositories.Interfaces;
using Projeto_PetShop.Aplication.ServiceResult;

public class TutorService : ITutorService
{
    private readonly ITutorRepository _tutorRepository; // Variavel de injeção

    public TutorService(ITutorRepository tutorRepository) // Injeção de dependência do repositório
    {
        _tutorRepository = tutorRepository;
    }

    public async Task<ServiceResult<Tutor>> CreateAsync(Tutor tutor)
    {
        if (tutor == null)
        {
            return ServiceResult<Tutor>.Fail("Tutor não pode ser vázio. Preencha os dados requisitados.");
        }

        var tutores = await _tutorRepository.GetAllAsync();
        bool jaCadastrado = tutores.Any(t => t.Email == tutor.Email);

        if (jaCadastrado)
        {

            return ServiceResult<Tutor>.Fail("E-mail já cadastrado no sistema.");
        }

        var cadastrado = await _tutorRepository.CreateAsync(tutor);
        if (cadastrado == null)
        {
            return ServiceResult<Tutor>.Fail("Não foi possível cadastrar o usuário. Tente novamente.");
        }
        return ServiceResult<Tutor>.Ok(cadastrado, "Usuário cadastrado com Sucesso! testando");
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

    public async Task<ServiceResult<Tutor>> UpdateAsync(Tutor tutor)
    {
        if (tutor == null)
        {

            return ServiceResult<Tutor>.Fail("Tutor não pode ser vázio. Preencha os dados requisitados.");
        }

        var tutorExiste = await _tutorRepository.GetByIdAsync(tutor.Id);

        if (tutorExiste == null)
        {
            return ServiceResult<Tutor>.Fail("Tutor não encontrado. Tente novamente.");
        }

        var resposta = await _tutorRepository.UpdateAsync(tutor);
        return ServiceResult<Tutor>.Ok(resposta, "Usuário atualizado com sucesso!");
    }

    public async Task<ServiceResult<bool>> DeleteAsync(int id)
    {

        var tutorExiste = await _tutorRepository.GetByIdAsync(id);

        if (tutorExiste == null)
        {
            return ServiceResult<bool>.Fail("Tutor não encontrado. Tente novamente.");
        }

        var resposta = await _tutorRepository.DeleteAsync(tutorExiste);
        return ServiceResult<bool>.Ok(resposta, "Tutor Excluido com sucesso!");
    }
}