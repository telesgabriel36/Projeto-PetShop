using Projeto_PetShop.Models;
using Microsoft.AspNetCore.Mvc;
using Projeto_PetShop.Service.Interface;

namespace Projeto_PetShop.Controllers;

public class ServicoController : Controller
{
    private readonly IServicoService _servicoService;

    public ServicoController(IServicoService servicoService)
    {
        _servicoService = servicoService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var servicos = await _servicoService.GetAllAsync();
        return View(servicos);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] //Método para enviar os dado do novo serviço
    public async Task<IActionResult> Create(Servico servico)
    {
        if (ModelState.IsValid)
        {
            var resposta = await _servicoService.CreateAsync(servico);
            if (!resposta.Success)
            {
                ViewBag.ErrorMessage = resposta.Message;
                return View();
            }
            TempData["MensagemSucesso"] = resposta.Message;
            return RedirectToAction("Index");
        }
        return View(servico);
    }

    [HttpGet] //View para verificar dados do serviço
    public async Task<IActionResult> Details(int id)
    {
        var servico = await _servicoService.GetByIdAsync(id);
        return View(servico.Data);
    }

    [HttpGet] //Método para exibir a view de edição do tutor
    public async Task<IActionResult> Edit(int id)
    {
        var servico = await _servicoService.GetByIdAsync(id);
        if (servico.Data == null)
        {
            return NotFound();
        }
        return View(servico.Data);
    }

    [HttpPost] //Método para atualizar os dados do tutor
    public async Task<IActionResult> Edit(Servico servico)
    {
        if (ModelState.IsValid)
        {

            var atualizacao = await _servicoService.UpdateAsync(servico);
            if (!atualizacao.Success)
            {
                ViewBag.ErrorMessage = atualizacao.Message;
                return NotFound();
            }

            TempData["MensagemSucesso"] = atualizacao.Message;
            return RedirectToAction("Index");
        }
        return View(servico);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var servico = await _servicoService.GetByIdAsync(id);

        return View(servico.Data);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {

        if (ModelState.IsValid)
        {
            var exclusao = await _servicoService.DeleteAsync(id);
            if (!exclusao.Success)
            {
                var servico = await _servicoService.GetByIdAsync(id);
                ViewBag.ErrorMessage = "Não foi possível deletar este tutor. Tente novamente.";
                return View(servico);
            }
            TempData["MensagemSucesso"] = exclusao.Message;
            return RedirectToAction("Index");
        }

        return View("index");
    }

}