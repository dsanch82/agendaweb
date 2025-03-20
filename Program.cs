using Microsoft.EntityFrameworkCore;
using AgendaWeb.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseSqlite(connectionString)); // Usa el proveedor adecuado

// Configurar el puerto manualmente si Render lo requiere
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://*:{port}");

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar middleware
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
