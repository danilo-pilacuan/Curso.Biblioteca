using Curso.Biblioteca.Domain;

using System.Text.Json;

namespace Curso.Biblioteca.Application;

public class LibroAppService:ILibroAppService
{
    private readonly ILibroRepository repository;
    private readonly IUnitOfWork unitOfWork;

    public LibroAppService(ILibroRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<LibroCreadoDto> CreateAsync(LibroCreateUpdateDto libroDto)
    {
        
        //Reglas Validaciones... 
        // var existeNombreMarca = await repository.ExisteNombre(libroDto.Nombre);
        // if (existeNombreMarca){
        //     throw new ArgumentException($"Ya existe una libro con el nombre {libroDto.Nombre}");
        // }
 
        //Mapeo Dto => Entidad
        var libro = new Libro();
        libro.Titulo = libroDto.Titulo;
        libro.Genero = libroDto.Genero;
        libro.Sinopsis = libroDto.Sinopsis;
        libro.Existencias = libroDto.Existencias;
        libro.FechaPublicacion = libroDto.FechaPublicacion;
        libro.AutorId = libroDto.AutorId;
        libro.EditorialId = libroDto.EditorialId;
        
        
        System.Console.WriteLine(JsonSerializer.Serialize(libro));
 
        //Persistencia objeto
        libro = await repository.AddAsync(libro);
        await unitOfWork.SaveChangesAsync();

        //Mapeo Entidad => Dto
        var libroCreado = new LibroCreadoDto();
        
        libroCreado.Id = libro.Id;
        libroCreado.Titulo = libro.Titulo;
        libroCreado.Genero = libro.Genero;
        libroCreado.Sinopsis = libro.Sinopsis;
        libroCreado.Existencias = libro.Existencias;
        libroCreado.FechaPublicacion = libro.FechaPublicacion;
        libroCreado.AutorId = libro.AutorId;
        libroCreado.EditorialId = libro.EditorialId;

        return libroCreado;
    }

    public async Task UpdateAsync(int id, LibroCreateUpdateDto libroDto)
    {
        var libro = await repository.GetByIdAsync(id);
        if (libro == null){
            throw new ArgumentException($"El libro con el id: {id}, no existe");
        }
        
        // var existeNombreMarca = await repository.ExisteNombre(libroDto.Nombre,id);
        // if (existeNombreMarca){
        //     throw new ArgumentException($"Ya existe una libro con el nombre {libroDto.Nombre}");
        // }

        //Mapeo Dto => Entidad
        // libro.Nombres = libroDto.Nombres;
        // libro.Apellidos = libroDto.Nombres;
        // libro.Nacionalidad = libroDto.Nacionalidad;

        // libro.Id = libroDto.Id;
        libro.Titulo = libroDto.Titulo;
        libro.Genero = libroDto.Genero;
        libro.Sinopsis = libroDto.Sinopsis;
        libro.Existencias = libroDto.Existencias;
        libro.FechaPublicacion = libroDto.FechaPublicacion;
        libro.AutorId = libroDto.AutorId;
        libro.EditorialId = libroDto.EditorialId;
        // libro.Autor = libroDto.Autor;
        // libro.Editorial = libroDto.Editorial;

        //Persistencia objeto
        await repository.UpdateAsync(libro);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }

    public async Task<bool> DeleteAsync(int libroId)
    {
        var libro = await repository.GetByIdAsync(libroId);
        if (libro == null){
            throw new ArgumentException($"El libro con el id: {libroId}, no existe");
        }

        repository.Delete(libro);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<LibroDto> GetAll()
    {
        var libroesList = repository.GetAll();

        var libroesListDto =  from l in libroesList
                            select new LibroDto(){
                                Id = l.Id,
                                Titulo = l.Titulo,
                                Genero = l.Genero,
                                Sinopsis = l.Sinopsis,
                                Existencias = l.Existencias,
                                FechaPublicacion = l.FechaPublicacion,
                                AutorId = l.AutorId,
                                EditorialId = l.EditorialId,
                                Autor=l.Autor,
                                Editorial=l.Editorial
                            };

        return libroesListDto.ToList();
    }

}
