using Ejercicio.Prueba.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Prueba.Infraestructure;

public class EstudianteDbContext : DbContext, IUnitOfWork
{
    public DbSet<Estudiante> Estudiantes {get; set;}

    public string DbPath {get; set;}

    public EstudianteDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "ejercicio.prueba.estudiante");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

}
