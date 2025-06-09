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

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Tutor tutor)
    {
        if (ModelState.IsValid)
        {
            await _TutorService.CreateAsync(tutor);
            return RedirectToAction("Index");
        }
        return View(tutor);
    }


}