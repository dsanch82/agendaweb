using Microsoft.EntityFrameworkCore;
using AgendaWeb.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexi�n a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseSqlite(connectionString)); // Cambia a UseSqlServer o UseNpgsql seg�n tu base de datos

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el middleware de la aplicaci�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

