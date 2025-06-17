namespace Projeto_PetShop.Service.Implementation
{
    using Projeto_PetShop.Models;
    using Projeto_PetShop.Service.Interface;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Projeto_PetShop.Repositories.Interfaces;
    using Projeto_PetShop.Aplication.ServiceResult;

    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IAgendamentoRepository _agendamentoRepository;

        public PagamentoService(IPagamentoRepository pagamentoRepository, IAgendamentoRepository agendamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<ServiceResult<Pagamento>> CreateAsync(Pagamento pagamento)
        {
            if (pagamento == null)
                return ServiceResult<Pagamento>.Fail("Pagamento não pode ser nulo.");

            // Validar se o agendamento existe
            var agendamento = await _agendamentoRepository.GetByIdAsync(pagamento.AgendamentoId);
            if (agendamento == null)
                return ServiceResult<Pagamento>.Fail("Agendamento não encontrado.");

            // Validar se o pagamento não foi feito para o mesmo agendamento
            var pagamentoExistente = await _pagamentoRepository.GetAllAsync();
            if (pagamentoExistente.Any(p => p.AgendamentoId == pagamento.AgendamentoId))
                return ServiceResult<Pagamento>.Fail("Já existe um pagamento para este agendamento.");

            // Criar pagamento
            var criado = await _pagamentoRepository.CreateAsync(pagamento);

            if (criado == null)
                return ServiceResult<Pagamento>.Fail("Erro ao registrar pagamento. Tente novamente.");

            return ServiceResult<Pagamento>.Ok(criado, "Pagamento registrado com sucesso!");
        }

        public async Task<ServiceResult<Pagamento?>> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return ServiceResult<Pagamento>.Fail("Pagamento não encontrado.");
            }

            var pagamento = await _pagamentoRepository.GetByIdAsync(id);

            if (pagamento == null)
            {
                return ServiceResult<Pagamento>.Fail("Pagamento não encontrado.");
            }

            return ServiceResult<Pagamento>.Ok(pagamento);
        }

        public async Task<IEnumerable<Pagamento>> GetAllAsync()
        {
            return await _pagamentoRepository.GetAllAsync();
        }

        public async Task<ServiceResult<Pagamento>> UpdateAsync(Pagamento pagamento)
        {
            if (pagamento == null)
                return ServiceResult<Pagamento>.Fail("Pagamento não pode ser nulo.");

            var existe = await _pagamentoRepository.GetByIdAsync(pagamento.Id);
            if (existe == null)
                return ServiceResult<Pagamento>.Fail("Pagamento não encontrado.");

            var atualizado = await _pagamentoRepository.UpdateAsync(pagamento);
            return ServiceResult<Pagamento>.Ok(atualizado, "Pagamento atualizado com sucesso!");
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var existe = await _pagamentoRepository.GetByIdAsync(id);
            if (existe == null)
                return ServiceResult<bool>.Fail("Pagamento não encontrado.");

            var deletado = await _pagamentoRepository.DeleteAsync(existe);
            return ServiceResult<bool>.Ok(deletado, "Pagamento excluído com sucesso!");
        }
    }
}
