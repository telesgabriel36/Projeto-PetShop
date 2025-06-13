namespace Projeto_PetShop.Service.Implementation;

using Projeto_PetShop.Models;
using Projeto_PetShop.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto_PetShop.Repositories.Interfaces;
using Projeto_PetShop.Aplication.ServiceResult;

public class ServicoService : IServicoService
{
    readonly private IServicoRepository _servicoRepository;

    public ServicoService(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }

    public async Task<ServiceResult<Servico>> CreateAsync(Servico servico)
    {
        if (servico == null)
        {
            return ServiceResult<Servico>.Fail("Serviço não pode ser vázio. Preencha os dados requisitados.");
        }
        var servicos = await _servicoRepository.GetAllAsync();
        bool servicoExiste  = servicos.Any(servicoBd => servicoBd.Nome == servico.Nome);

        if (servicoExiste )
        {
            return ServiceResult<Servico>.Fail("Servico já cadastrado no sistema.");
        }

        var cadastrado = await _servicoRepository.CreateAsync(servico);
        if (cadastrado == null)
        {
            return ServiceResult<Servico>.Fail("Não foi possível cadastrar o servico. Tente novamente.");
        }
        return ServiceResult<Servico>.Ok(cadastrado, "Serviço cadastrado com Sucesso!");
    }

    public async Task<ServiceResult<bool>> DeleteAsync(int id)
    {
        var servicoExiste = await _servicoRepository.GetByIdAsync(id);

        if (servicoExiste == null)
        {
            return ServiceResult<bool>.Fail("Serviço não encontrado. Tente novamente.");
        }

        var resposta = await _servicoRepository.DeleteAsync(servicoExiste);
        return ServiceResult<bool>.Ok(resposta, "Serviço Excluido com sucesso!");
    }

    public async Task<IEnumerable<Servico>> GetAllAsync()
    {
        return await _servicoRepository.GetAllAsync();
    }

    public async Task<ServiceResult<Servico?>> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            return ServiceResult<Servico?>.Fail("Serviço não encontrado. Número de identificação inválido.");
        }
        var servico = await _servicoRepository.GetByIdAsync(id);

        if (servico == null)
        { 
            return ServiceResult<Servico>.Fail("Serviço não encontrado no banco de dados.");
        }
        return ServiceResult<Servico>.Ok(servico);
    }

    public async Task<ServiceResult<Servico>> UpdateAsync(Servico servico)
    {
        if (servico == null)
        {

            return ServiceResult<Servico>.Fail("Serviço não pode ser vázio. Preencha os dados requisitados.");
        }

        var servicoExiste = await _servicoRepository.GetByIdAsync(servico.Id);

        if (servicoExiste == null)
        {
            return ServiceResult<Servico>.Fail("Serviço não encontrado. Tente novamente.");
        }

        var resposta = await _servicoRepository.UpdateAsync(servico);
        return ServiceResult<Servico>.Ok(resposta, "Serviço atualizado com sucesso!");
    }
}