using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio.Prueba.Application;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio.Prueba.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EstudianteController : ControllerBase
{
    private readonly IEstudianteAppService estudianteAppService;

    public EstudianteController(IEstudianteAppService estudianteAppService)
    {
        this.estudianteAppService = estudianteAppService;
    }


    [HttpGet]
    public ICollection<EstudianteDto> GetAll()
    {
        return estudianteAppService.GetAll();
    }

    [HttpPost]
    public async Task<EstudianteDto> CreateAsync(EstudianteCrearActualizarDto estudiante)
    {
        return await estudianteAppService.CreateAsync(estudiante);
    }

    [HttpPut]
    public async Task UpdateAsync(int id, EstudianteCrearActualizarDto estudiante)
    {
        await estudianteAppService.UpdateAsync(id, estudiante);
    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int estudianteId)
    {
        return await estudianteAppService.DeleteAsync(estudianteId);
    }


}
