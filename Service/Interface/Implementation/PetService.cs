namespace Projeto_PetShop.Service.Implementation;

using Projeto_PetShop.Models;
using Projeto_PetShop.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto_PetShop.Repositories.Interfaces;
using Projeto_PetShop.Aplication.ServiceResult;

public class PetService : IPetService
{
    readonly private IPetRepository _petRepository;

    public PetService(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<ServiceResult<Pet>> CreateAsync(Pet pet)
    {

        if (pet == null)
        {
            return ServiceResult<Pet>.Fail("Pet não pode ser vázio. Preencha os dados requisitados.");
        }

        if (pet.TutorId <= 0)
        {
            return ServiceResult<Pet>.Fail("O pet deve estar associado a um tutor.");
        }

        var jaCadastrado = await _petRepository.GetAllAsync();

        if (jaCadastrado.Any(p => p.TutorId == pet.TutorId))
        {

            return ServiceResult<Pet>.Fail("Tutor já associado a outro Pet no sistema. Tente novamente");
        }


        DateTime dataAtual = DateTime.Now;
        if (pet.DataNascimento > dataAtual)
        {
            return ServiceResult<Pet>.Fail($"A data de nascimento não pode ser maior que a data atual {dataAtual}");
        }

        var cadastrado = await _petRepository.CreateAsync(pet);
        if (cadastrado == null)
        {
            return ServiceResult<Pet>.Fail("Não foi possível cadastrar o pet. Tente novamente.");
        }
        return ServiceResult<Pet>.Ok(cadastrado, "Pet cadastrado com Sucesso!");

    }

    public async Task<ServiceResult<bool>> DeleteAsync(int id)
    {
        var petExiste = await _petRepository.GetByIdAsync(id);

        if (petExiste == null)
        {
            return ServiceResult<bool>.Fail("Pet não encontrado. Tente novamente.");
        }

        var resposta = await _petRepository.DeleteAsync(petExiste);
        return ServiceResult<bool>.Ok(resposta, "Pet Excluido com sucesso!");
    }

    public async Task<IEnumerable<Pet>> GetAllAsync()
    {
        return await _petRepository.GetAllAsync();
    }

    public async Task<ServiceResult<Pet?>> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            return ServiceResult<Pet?>.Fail("ID do pet não encontrada");
        }
        var pet = await _petRepository.GetByIdAsync(id);
        return ServiceResult<Pet>.Ok(pet);
    }

    public async Task<ServiceResult<Pet>> UpdateAsync(Pet pet)
    {
        if (pet == null)
        {

            return ServiceResult<Pet>.Fail("Pet não pode ser vázio. Preencha os dados requisitados.");
        }

        var petExiste = await _petRepository.GetByIdAsync(pet.Id);

        if (petExiste == null)
        {
            return ServiceResult<Pet>.Fail("Pet não encontrado. Tente novamente.");
        }

        var resposta = await _petRepository.UpdateAsync(pet);
        return ServiceResult<Pet>.Ok(resposta, "Pet atualizado com sucesso!");
    }
}