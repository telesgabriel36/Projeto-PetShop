
using Microsoft.EntityFrameworkCore;
using Projeto_PetShop.Models;
namespace Projeto_PetShop.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    public DbSet<Tutor> Tutores { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }

}