using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Prueba.Application;

public interface IEstudianteAppService
{
    ICollection<EstudianteDto> GetAll();
    Task<EstudianteDto> CreateAsync(EstudianteCrearActualizarDto estudianteDto);
    Task UpdateAsync (int id, EstudianteCrearActualizarDto estudianteDto);
    Task<bool> DeleteAsync(int id);
}
