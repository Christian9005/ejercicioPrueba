using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio.Prueba.Domain;

namespace Ejercicio.Prueba.Application;

public class EstudianteCrearActualizarDto
{
    [Required]
    [StringLength(Constants.NAME_MAX_LEN)]
    public string? Name {get; set;} 
}
