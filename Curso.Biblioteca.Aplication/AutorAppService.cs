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

    public async Task<AutorDto> CreateAsync(AutorCreateUpdateDto marcaDto)
    {
        
        //Reglas Validaciones... 
        // var existeNombreMarca = await repository.ExisteNombre(marcaDto.Nombre);
        // if (existeNombreMarca){
        //     throw new ArgumentException($"Ya existe una marca con el nombre {marcaDto.Nombre}");
        // }
 
        //Mapeo Dto => Entidad
        var autor = new Autor();
        autor.Nombres = marcaDto.Nombres;
 
        //Persistencia objeto
        autor = await repository.AddAsync(autor);
        await unitOfWork.SaveChangesAsync();

        //Mapeo Entidad => Dto
        var autorCreado = new AutorDto();
        autorCreado.Nombres = autor.Nombres;
        autorCreado.Id = autor.Id;

        //TODO: Enviar un correo electronica... 

        return autorCreado;
    }

    public async Task UpdateAsync(int id, MarcaCrearActualizarDto marcaDto)
    {
        var marca = await repository.GetByIdAsync(id);
        if (marca == null){
            throw new ArgumentException($"La marca con el id: {id}, no existe");
        }
        
        var existeNombreMarca = await repository.ExisteNombre(marcaDto.Nombre,id);
        if (existeNombreMarca){
            throw new ArgumentException($"Ya existe una marca con el nombre {marcaDto.Nombre}");
        }

        //Mapeo Dto => Entidad
        marca.Nombre = marcaDto.Nombre;

        //Persistencia objeto
        await repository.UpdateAsync(marca);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }

    public async Task<bool> DeleteAsync(int marcaId)
    {
        //Reglas Validaciones... 
        var marca = await repository.GetByIdAsync(marcaId);
        if (marca == null){
            throw new ArgumentException($"La marca con el id: {marcaId}, no existe");
        }

        repository.Delete(marca);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<MarcaDto> GetAll()
    {
        var marcaList = repository.GetAll();

        var marcaListDto =  from m in marcaList
                            select new MarcaDto(){
                                Id = m.Id,
                                Nombre = m.Nombre
                            };

        return marcaListDto.ToList();
    }

}
