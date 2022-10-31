using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio.Prueba.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio.Prueba.Infraestructure;

public class EstudianteRepository : EfRepository<Estudiante>, IEstudianteRepository
{
    public EstudianteRepository(EstudianteDbContext context): base(context)
    {
    }

    public async Task<bool> ExistName(string name)
    {
        var resultado = await this._context.Set<Estudiante>()
                                  .AnyAsync(x => x.Name.ToUpper() == name.ToUpper());
        
        return resultado;
    }

    public async Task<bool> ExistName(string name, int idExclud)
    {
        var query = this._context.Set<Estudiante>()
                        .Where(x => x.Id != idExclud)
                        .Where(x => x.Name.ToUpper() == name.ToUpper());
        
        var resultado = await query.AnyAsync();
        return resultado;
    }
}
