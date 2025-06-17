namespace Projeto_PetShop.Service.Implementation;

using Projeto_PetShop.Models;
using Projeto_PetShop.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto_PetShop.Repositories.Interfaces;
using Projeto_PetShop.Aplication.ServiceResult;
using System.Reflection.Metadata.Ecma335;

public class AgendamentoService : IAgendamentoService
{
    private readonly IAgendamentoRepository _agendamentoRepository;

    public AgendamentoService(IAgendamentoRepository agendamentoRepository)
    {
        _agendamentoRepository = agendamentoRepository;
    }

    public async Task<ServiceResult<Agendamento>> CreateAsync(Agendamento agendamento)
    {
        if (agendamento == null)
            return ServiceResult<Agendamento>.Fail("Agendamento não pode ser nulo.");

        if (agendamento.DataHoraAtendimento <= agendamento.DataHoraAgendamento)
        {
            return ServiceResult<Agendamento>.Fail($"A data e hora de agendamento deve ser maior que a data e hora atual: {agendamento.DataHoraAgendamento} ");
        }

        var agendamentos = await _agendamentoRepository.GetAllAsync();

        if (agendamentos.Any(agd => agd.DataHoraAtendimento == agendamento.DataHoraAtendimento))
        {
            return ServiceResult<Agendamento>.Fail($"Data e horário ({agendamento.DataHoraAtendimento}) não disponíveis. Tente uma nova data e horário.");
        }

        var criado = await _agendamentoRepository.CreateAsync(agendamento);

        if (criado == null)
            return ServiceResult<Agendamento>.Fail("Erro ao tentar agendar. Tente novamente.");

        return ServiceResult<Agendamento>.Ok(criado, "Agendamento realizado com sucesso!");
    }

    public async Task<ServiceResult<Agendamento?>> GetByIdAsync(int id)
    {
        if (id <= 0)
        {

            return ServiceResult<Agendamento>.Fail("Agendamento não encontrado.");
        }
        var agendamento = await _agendamentoRepository.GetByIdAsync(id);

        if (agendamento == null)
        {
            return ServiceResult<Agendamento>.Fail("Agendamento não encontrado.");
        }
        return ServiceResult<Agendamento>.Ok(agendamento);
    }

    public async Task<IEnumerable<Agendamento>> GetAllAsync()
    {
        return await _agendamentoRepository.GetAllAsync();
    }

    public async Task<ServiceResult<Agendamento>> UpdateAsync(Agendamento agendamento)
    {
        if (agendamento == null)
            return ServiceResult<Agendamento>.Fail("Agendamento não pode ser nulo.");

        var existe = await _agendamentoRepository.GetByIdAsync(agendamento.Id);
        if (existe == null)
            return ServiceResult<Agendamento>.Fail("Agendamento não encontrado.");

        var atualizado = await _agendamentoRepository.UpdateAsync(agendamento);
        return ServiceResult<Agendamento>.Ok(atualizado, "Agendamento atualizado com sucesso!");
    }

    public async Task<ServiceResult<bool>> DeleteAsync(int id)
    {
        var existe = await _agendamentoRepository.GetByIdAsync(id);
        if (existe == null)
            return ServiceResult<bool>.Fail("Agendamento não encontrado.");

        var deletado = await _agendamentoRepository.DeleteAsync(existe);
        return ServiceResult<bool>.Ok(deletado, "Agendamento excluído com sucesso!");
    }

}
