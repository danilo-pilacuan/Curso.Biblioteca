using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Infraestructure;

public class EditorialRepository:EFRepository<Editorial>,IEditorialRepository
{
    public EditorialRepository(BibliotecaDbContext context):base(context)
    {

    }

    
}
