namespace Projeto_PetShop.ViewModels;

using System.Collections.Generic;

using Projeto_PetShop.Models;

public class PetEditViewModel
{
    public Pet Pet { get; set; }
    public IEnumerable<Tutor> Tutores { get; set; } = new List<Tutor>();
}