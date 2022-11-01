using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Infraestructure;

public class LibroRepository:EFRepository<Libro>,ILibroRepository
{
    public LibroRepository(BibliotecaDbContext context):base(context)
    {

    }
}


