using Curso.Biblioteca.Domain;


namespace Curso.Biblioteca.Infraestructure;

public class AutorRepository:EFRepository<Autor>,IAutorRepository
{
    public AutorRepository(BibliotecaDbContext context):base(context)
    {

    }
}

