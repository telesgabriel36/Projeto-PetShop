using Projeto_PetShop.Models;
using Projeto_PetShop.Service.Interface;
using Projeto_PetShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Projeto_PetShop.Controllers;

public class TutorController : Controller
{
    private readonly ITutorService _TutorService;

    public TutorController(ITutorService tutorService)
    {
        _TutorService = tutorService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var tutores = await _TutorService.GetAllAsync();
        return View(tutores);
    }

    [HttpGet] //View para cadastrar um novo tutor
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] //Método para enviar os dado do novo tutor a service
    public async Task<IActionResult> Create(Tutor tutor)
    {
        if (ModelState.IsValid)
        {
            var resposta = await _TutorService.CreateAsync(tutor);
            if (!resposta.Success)
            {
                ViewBag.ErrorMessage = resposta.Message;
                return View();
            }
            TempData["MensagemSucesso"] = resposta.Message;
            return RedirectToAction("Index");
        }
        return View(tutor);
    }

    [HttpGet] //View para verificar dados do tutor
    public async Task<IActionResult> Details(int id)
    {
        var tutor = await _TutorService.GetByIdAsync(id);
        return View(tutor);
    }


    [HttpGet] //Método para exibir a view de edição do tutor
    public async Task<IActionResult> Edit(int id)
    {
        var tutor = await _TutorService.GetByIdAsync(id);
        if (tutor == null)
        {
            return NotFound();
        }
        return View(tutor);
    }

    [HttpPost] //Método para atualizar os dados do tutor
    public async Task<IActionResult> Edit(Tutor tutor)
    {
        if (ModelState.IsValid)
        {

            var atualizacao = await _TutorService.UpdateAsync(tutor);
            if (!atualizacao.Success)
            {
                ViewBag.ErrorMessage = atualizacao.Message;
                return NotFound();
            }

            TempData["MensagemSucesso"] = atualizacao.Message;
            return RedirectToAction("Index");
        }
        return View(tutor);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var tutor = await _TutorService.GetByIdAsync(id);

        return View(tutor);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {

        if (ModelState.IsValid)
        {
            var exclusao = await _TutorService.DeleteAsync(id);
            if (!exclusao.Success)
            {
                var tutor = await _TutorService.GetByIdAsync(id);
                ViewBag.ErrorMessage = "Não foi possível deletar este tutor. Tente novamente.";
                return View(tutor);
            }
            TempData["MensagemSucesso"] = exclusao.Message;
            return RedirectToAction("Index");
        }

        return View("index");
    }

}