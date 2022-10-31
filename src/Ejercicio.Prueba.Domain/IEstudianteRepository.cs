using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Prueba.Domain;

public interface IEstudianteRepository: IRepository<Estudiante>
{
    Task<bool> ExistName(string name);
    Task<bool> ExistName(string name, int idExclud);

}