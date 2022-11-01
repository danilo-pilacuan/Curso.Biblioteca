using System.ComponentModel.DataAnnotations;
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Application;

public interface IAutorAppService
{
    ICollection<AutorDto> GetAll();

    Task<AutorDto> CreateAsync(AutorCreateUpdateDto editorial);

    Task UpdateAsync (int id, AutorCreateUpdateDto editorial);

    Task<bool> DeleteAsync(int editorialId);
}
