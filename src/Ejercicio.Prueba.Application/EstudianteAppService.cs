using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio.Prueba.Domain;

namespace Ejercicio.Prueba.Application;

public class EstudianteAppService : IEstudianteAppService
{
    private readonly IEstudianteRepository repository;
    public EstudianteAppService(IEstudianteRepository repository)
    {
            this.repository = repository;
    }

    public async Task<EstudianteDto> CreateAsync(EstudianteCrearActualizarDto estudianteDto)
    {
        var existNameEstudiante = await repository.ExistName(estudianteDto.Name);
        if(existNameEstudiante)
        {
            throw new ArgumentException($"Ya exite un estudiante con el nombre {estudianteDto.Name}");
        }

        var estudiante = new Estudiante();
        estudiante.Name = estudianteDto.Name;

        estudiante = await repository.AddAsync(estudiante);

        var estudianteCreado = new EstudianteDto();
        estudianteCreado.Name = estudiante.Name;
        estudianteCreado.Id = estudiante.Id;

        return estudianteCreado;
    }

    public async Task<bool> DeleteAsync(int estudianteId)
    {
        var estudiante = await repository.GetByIdAsync(estudianteId);
        if (estudiante == null)
        {
            throw new ArgumentException($"El estudiante con el id: {estudianteId}, no existe"); 
        }

        repository.Delete(estudiante);

        return true;
    }

    public ICollection<EstudianteDto> GetAll()
    {
        var estudianteLista = repository.GetAll();

        var estudianteListaDto = from e in estudianteLista
                                 select new EstudianteDto{
                                    Id = e.Id,
                                    Name = e.Name
                                 };

        return estudianteListaDto.ToList();
    }

    public async Task UpdateAsync(int id, EstudianteCrearActualizarDto estudianteDto)
    {
        var estudiante = await repository.GetByIdAsync(id);
        if (estudiante == null)
        {
            throw new ArgumentException($"El estudiante con el id: {id} no existe!!");
        }

        var existNameEstudiante = await repository.ExistName(estudianteDto.Name, id);
        if (existNameEstudiante)
        {
            throw new ArgumentException($"Ya existe un estudiante con el nombre: {estudianteDto.Name}");   
        }

        estudiante.Name = estudianteDto.Name;

        await repository.UpdateAsync(estudiante);

        return;
    }
}
