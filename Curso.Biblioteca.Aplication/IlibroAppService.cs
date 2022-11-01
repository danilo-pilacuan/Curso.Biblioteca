namespace Curso.Biblioteca.Aplication;

public interface IlibroAppService
{
    ICollection<LibroDto> GetAll();

    Task<LibroDto> CreateAsync(LibroCreateUpdateDto libro);

    Task UpdateAsync (int id, LibroCreateUpdateDto libro);

    Task<bool> DeleteAsync(int libroId);
}
