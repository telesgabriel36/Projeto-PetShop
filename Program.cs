using Microsoft.EntityFrameworkCore;
using Projeto_PetShop.Data;
using Projeto_PetShop.Repositories.Interfaces;
using Projeto_PetShop.Repositories.Implementations;
using Projeto_PetShop.Service.Interface;
using Projeto_PetShop.Service.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//Registrando os repositórios e serviços
builder.Services.AddScoped<ITutorService, TutorService>();
builder.Services.AddScoped<ITutorRepository, TutorRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
