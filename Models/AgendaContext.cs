using Microsoft.EntityFrameworkCore;

namespace AgendaWeb.Models;

public class AgendaContext : DbContext
{
    // Constructor necesario para recibir las opciones configuradas desde Program.cs
    public AgendaContext(DbContextOptions<AgendaContext> options)
        : base(options)
    {
    }

    public DbSet<Tarea> Tareas { get; set; }
}
