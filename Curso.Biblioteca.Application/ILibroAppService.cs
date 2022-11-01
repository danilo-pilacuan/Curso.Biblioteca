namespace Curso.Biblioteca.Application;

public interface ILibroAppService
{
    ICollection<LibroDto> GetAll();

    Task<LibroDto> CreateAsync(LibroCreateUpdateDto libro);

    Task UpdateAsync (int id, LibroCreateUpdateDto libro);

    Task<bool> DeleteAsync(int libroId);
}
