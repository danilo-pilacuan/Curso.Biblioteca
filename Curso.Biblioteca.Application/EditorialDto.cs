using System.ComponentModel.DataAnnotations;
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Application;

public class EditorialDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Nombre { get; set; }
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Pais { get; set; }
}
