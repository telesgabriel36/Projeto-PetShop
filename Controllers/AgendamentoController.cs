using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_PetShop.Models;
using Projeto_PetShop.Service.Implementation;
using Projeto_PetShop.Service.Interface;
using Projeto_PetShop.ViewModels;

namespace Projeto_PetShop.Controllers;


public class AgendamentoController : Controller
{
    private readonly IAgendamentoService _agendamentoService;
    private readonly IPetService _petService;
    private readonly IServicoService _servicoService;

    public AgendamentoController(IAgendamentoService agendamentoService, IPetService petService, IServicoService servicoService)
    {
        _agendamentoService = agendamentoService;
        _petService = petService;
        _servicoService = servicoService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var agendamentos = await _agendamentoService.GetAllAsync();
        return View(agendamentos);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var pets = await _petService.GetAllAsync();
        var servicos = await _servicoService.GetAllAsync();

        var viewModel = new AgendamentoCreateViewModel
        {
            Pets = pets.ToList(),
            Servicos = servicos.ToList(),
            Agendamento = new Agendamento()
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AgendamentoCreateViewModel model)
    {
        var novoAgendamento = model.Agendamento;
        novoAgendamento.DataHoraAgendamento = DateTime.Now;
        novoAgendamento.status = Enums.Agendamento.StatusAgendamento.Agendado;

        if (!ModelState.IsValid)
        {
            model.Pets = (await _petService.GetAllAsync()).ToList();
            model.Servicos = (await _servicoService.GetAllAsync()).ToList();
            return View(model);
        }

        var resultado = await _agendamentoService.CreateAsync(model.Agendamento);
        if (!resultado.Success)
        {
            ViewBag.ErrorMessage = resultado.Message;
            model.Pets = (await _petService.GetAllAsync()).ToList();
            model.Servicos = (await _servicoService.GetAllAsync()).ToList();
            return View(model);
        }

        TempData["MensagemSucesso"] = resultado.Message;
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var resultado = await _agendamentoService.GetByIdAsync(id);
        if (resultado.Data == null)
            return NotFound();

        var viewModel = new AgendamentoCreateViewModel
        {
            Agendamento = resultado.Data,
            Pets = (await _petService.GetAllAsync()).ToList(),
            Servicos = (await _servicoService.GetAllAsync()).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AgendamentoCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Pets = (await _petService.GetAllAsync()).ToList();
            model.Servicos = (await _servicoService.GetAllAsync()).ToList();
            return View(model);
        }

        var resultado = await _agendamentoService.UpdateAsync(model.Agendamento);
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
        var resultado = await _agendamentoService.GetByIdAsync(id);
        if (resultado.Data == null)
            return NotFound();

        return View(resultado.Data);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var resultado = await _agendamentoService.GetByIdAsync(id);
        if (resultado.Data == null)
            return NotFound();

        return View(resultado.Data);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var resultado = await _agendamentoService.DeleteAsync(id);
        if (!resultado.Success)
        {
            ViewBag.ErrorMessage = resultado.Message;
            return View();
        }

        TempData["MensagemSucesso"] = resultado.Message;
        return RedirectToAction("Index");
    }
}
