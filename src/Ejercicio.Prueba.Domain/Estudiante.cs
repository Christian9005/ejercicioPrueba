using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Prueba.Domain;
public class Estudiante
{
    [Required]
    public int Id {get; set;}
    
    [Required]
    [StringLength(Constants.NAME_MAX_LEN)]
    public string? Name {get; set;}   
}