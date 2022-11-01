using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Aplication;

public class AutorAppService:IAutorAppService
{
     private readonly IAutorRepository repository;
    private readonly IUnitOfWork unitOfWork;

    public AutorAppService(IAutorRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<AutorDto> CreateAsync(AutorCreateUpdateDto autorDto)
    {
        
        //Reglas Validaciones... 
        // var existeNombreMarca = await repository.ExisteNombre(autorDto.Nombre);
        // if (existeNombreMarca){
        //     throw new ArgumentException($"Ya existe una autor con el nombre {autorDto.Nombre}");
        // }
 
        //Mapeo Dto => Entidad
        var autor = new Autor();
        autor.Nombres = autorDto.Nombres;
 
        //Persistencia objeto
        autor = await repository.AddAsync(autor);
        await unitOfWork.SaveChangesAsync();

        //Mapeo Entidad => Dto
        var autorCreado = new AutorDto();
        autorCreado.Nombres = autor.Nombres;
        autorCreado.Id = autor.Id;

        return autorCreado;
    }

    public async Task UpdateAsync(int id, AutorCreateUpdateDto autorDto)
    {
        var autor = await repository.GetByIdAsync(id);
        if (autor == null){
            throw new ArgumentException($"El autor con el id: {id}, no existe");
        }
        
        // var existeNombreMarca = await repository.ExisteNombre(autorDto.Nombre,id);
        // if (existeNombreMarca){
        //     throw new ArgumentException($"Ya existe una autor con el nombre {autorDto.Nombre}");
        // }

        //Mapeo Dto => Entidad
        autor.Nombres = autorDto.Nombres;

        //Persistencia objeto
        await repository.UpdateAsync(autor);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }

    public async Task<bool> DeleteAsync(int autorId)
    {
        var autor = await repository.GetByIdAsync(autorId);
        if (autor == null){
            throw new ArgumentException($"El autor con el id: {autorId}, no existe");
        }

        repository.Delete(autor);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<AutorDto> GetAll()
    {
        var autoresList = repository.GetAll();

        var autoresListDto =  from a in autoresList
                            select new AutorDto(){
                                Id = a.Id,
                                Nombres = a.Nombres,
                                Apellidos = a.Apellidos
                            };

        return autoresListDto.ToList();
    }

}
