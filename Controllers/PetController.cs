using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_PetShop.Models;
using Projeto_PetShop.Service.Implementation;
using Projeto_PetShop.Service.Interface;
using Projeto_PetShop.ViewModels;

namespace Projeto_PetShop.Controllers;

public class PetController : Controller
{
    readonly private IPetService _petService;
    readonly private ITutorService _tutorService;

    public PetController(IPetService petService, ITutorService tutorService)
    {
        _petService = petService;
        _tutorService = tutorService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var pets = await _petService.GetAllAsync();
        return View(pets);
    }

    [HttpGet] //View para cadastrar um novo Pet
    public async Task<IActionResult> Create()
    {
        var tutores = await _tutorService.GetAllAsync();
        var viewModel = new CreateViewModel
        {
            Pet = new Pet(),
            Tutores = tutores
        };
        return View(viewModel);
    }

    [HttpPost] //Método para enviar os dado do novo tutor a service
    public async Task<IActionResult> Create(CreateViewModel model)
    {
        if (model.Pet.TutorId == 0)
        {
            ModelState.AddModelError("Pet.TutorId", "É necessário selecionar um tutor.");
        }

        if (!ModelState.IsValid)
        {
            model.Tutores = await _tutorService.GetAllAsync();
            return View(model);
        }

        var resposta = await _petService.CreateAsync(model.Pet);
        if (!resposta.Success)
        {
            ViewBag.ErrorMessage = resposta.Message;
            var tutores = await _tutorService.GetAllAsync();
            var viewModel = new CreateViewModel
            {
                Pet = new Pet(),
                Tutores = tutores
            };
            return View(viewModel);
        }
        TempData["MensagemSucesso"] = resposta.Message;
        return RedirectToAction("Index");
    }

    [HttpGet] //View para verificar dados do Pet
    public async Task<IActionResult> Details(int id)
    {
        var pet = await _petService.GetByIdAsync(id);
        return View(pet.Data);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var resultado = await _petService.GetByIdAsync(id);
        if (resultado.Data == null)
            return NotFound();

        var tutores = await _tutorService.GetAllAsync();

        var viewModel = new PetEditViewModel
        {
            Pet = resultado.Data,
            Tutores = tutores
        };
        return View(viewModel);
    }

    [HttpPost] //Método para atualizar os dados do pet
    public async Task<IActionResult> Edit(PetEditViewModel model)
    {
        if (ModelState.IsValid)
        {

            var atualizacao = await _petService.UpdateAsync(model.Pet);
            if (!atualizacao.Success)
            {
                ViewBag.ErrorMessage = atualizacao.Message;
                return NotFound();
            }

            TempData["MensagemSucesso"] = atualizacao.Message;
            return RedirectToAction("Index");
        }
        return View(model.Pet);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var pet = await _petService.GetByIdAsync(id);

        return View(pet.Data);
    }

       [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {

        if (ModelState.IsValid)
        {
            var exclusao = await _petService.DeleteAsync(id);
            if (!exclusao.Success)
            {
                var pet = await _petService.GetByIdAsync(id);
                ViewBag.ErrorMessage = "Não foi possível deletar este Pet. Tente novamente.";
                return View(pet);
            }
            TempData["MensagemSucesso"] = exclusao.Message;
            return RedirectToAction("Index");
        }

        return View("index");
    }

}