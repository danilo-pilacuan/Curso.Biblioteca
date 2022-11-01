using System.ComponentModel.DataAnnotations;

namespace Curso.Biblioteca.Domain;

public class Autor
{
    

    [Required]
    public int Id { get; set; }
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
