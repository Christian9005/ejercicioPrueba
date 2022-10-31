using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Ejercicio.Prueba.Domain;

namespace Ejercicio.Prueba.Application;

public class EstudianteDto
{
    [Required]
    public int Id {get; set;}
    
    [Required]
    [StringLength(Constants.NAME_MAX_LEN)]
    public string? Name {get; set;} 
}
