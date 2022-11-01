using System.ComponentModel.DataAnnotations;
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Aplication;

public class LibroCreateUpdateDto
{
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
    public string Titulo { get; set; }
    [Required]
    [StringLength(DominioConstantes.DESCRIPCION_MAX)]
    public string Genero { get; set; }
    [Required]
    [StringLength(DominioConstantes.DESCRIPCION_MAX)]
    public string Sinopsis { get; set; }
    [Required]
    public DateTime FechaPublicacion { get; set; }
    [Required]
    public int Existencias{get;set;}
    [Required]
    public int AutorId { get; set; }
    [Required]
    public int EditorialId { get; set; }
    [Required]
    public Autor Autor { get; set; }
    [Required]
    public Editorial Editorial { get; set; }
}
