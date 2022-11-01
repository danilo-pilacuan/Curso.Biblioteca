using System.ComponentModel.DataAnnotations;
using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Application;

public interface IEditorialAppService
{
    ICollection<EditorialDto> GetAll();

    Task<EditorialDto> CreateAsync(EditorialCreateUpdateDto editorial);

    Task UpdateAsync (int id, EditorialCreateUpdateDto editorial);

    Task<bool> DeleteAsync(int editorialId);
}
