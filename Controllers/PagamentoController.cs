using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_PetShop.Models;
using Projeto_PetShop.Service.Implementation;
using Projeto_PetShop.Service.Interface;
using Projeto_PetShop.ViewModels;

namespace Projeto_PetShop.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly IPagamentoService _pagamentoService;
        private readonly IAgendamentoService _agendamentoService;

        public PagamentoController(IPagamentoService pagamentoService, IAgendamentoService agendamentoService)
        {
            _pagamentoService = pagamentoService;
            _agendamentoService = agendamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pagamentos = await _pagamentoService.GetAllAsync();
            return View(pagamentos);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int agendamentoId)
        {
            var agendamentoResult = await _agendamentoService.GetByIdAsync(agendamentoId);
            if (!agendamentoResult.Success)
                return NotFound();

            var viewModel = new PagamentoCreateViewModel
            {
                Agendamento = agendamentoResult.Data,
                Pagamento = new Pagamento { AgendamentoId = agendamentoId }
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PagamentoCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var resultado = await _pagamentoService.CreateAsync(model.Pagamento);
            if (!resultado.Success)
            {
                ViewBag.ErrorMessage = resultado.Message;
                return View(model);
            }

            TempData["MensagemSucesso"] = resultado.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var resultado = await _pagamentoService.GetByIdAsync(id);
            if (resultado.Data == null)
            {
                return NotFound();
            }


            var viewModel = new PagamentoCreateViewModel
            {
                Pagamento = resultado.Data,
                Agendamento = await _agendamentoService.GetByIdAsync(resultado.Data.AgendamentoId)
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PagamentoCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var resultado = await _pagamentoService.UpdateAsync(model.Pagamento);
            if (!resultado.Success)
            {
                ViewBag.ErrorMessage = resultado.Message;
                return View(model);
            }

            TempData["MensagemSucesso"] = resultado.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var resultado = await _pagamentoService.GetByIdAsync(id);
            if (resultado.Data == null)
                return NotFound();

            return View(resultado.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _pagamentoService.GetByIdAsync(id);
            if (resultado.Data == null)
                return NotFound();

            return View(resultado.Data);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultado = await _pagamentoService.DeleteAsync(id);
            if (!resultado.Success)
            {
                ViewBag.ErrorMessage = resultado.Message;
                return View();
            }

            TempData["MensagemSucesso"] = resultado.Message;
            return RedirectToAction("Index");
        }
    }
}
