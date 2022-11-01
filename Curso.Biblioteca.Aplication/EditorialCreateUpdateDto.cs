using System.ComponentModel.DataAnnotations;
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Aplication;

public class EditorialCreateUpdateDto
{
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Nombre { get; set; }
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Pais { get; set; }
}
