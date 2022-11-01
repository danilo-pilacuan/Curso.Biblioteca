using System.ComponentModel.DataAnnotations;
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Application;

public class AutorCreateUpdateDto
{
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Nombres { get; set; }
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Apellidos { get; set; }
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Nacionalidad { get; set; }
}
