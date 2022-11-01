using Curso.Biblioteca.Domain;

namespace Curso.Biblioteca.Aplication;

public class EditorialAppService:IEditorialAppService
{
    private readonly IEditorialRepository repository;
    private readonly IUnitOfWork unitOfWork;

    public EditorialAppService(IEditorialRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<EditorialDto> CreateAsync(EditorialCreateUpdateDto editorialDto)
    {
        
        //Reglas Validaciones... 
        // var existeNombreMarca = await repository.ExisteNombre(editorialDto.Nombre);
        // if (existeNombreMarca){
        //     throw new ArgumentException($"Ya existe una editorial con el nombre {editorialDto.Nombre}");
        // }
 
        //Mapeo Dto => Entidad
        var editorial = new Editorial();
        editorial.Nombre = editorialDto.Nombre;
 
        //Persistencia objeto
        editorial = await repository.AddAsync(editorial);
        await unitOfWork.SaveChangesAsync();

        //Mapeo Entidad => Dto
        var editorialCreado = new EditorialDto();
        editorialCreado.Nombre = editorial.Nombre;
        editorialCreado.Id = editorial.Id;

        return editorialCreado;
    }

    public async Task UpdateAsync(int id, EditorialCreateUpdateDto editorialDto)
    {
        var editorial = await repository.GetByIdAsync(id);
        if (editorial == null){
            throw new ArgumentException($"El editorial con el id: {id}, no existe");
        }
        
        // var existeNombreMarca = await repository.ExisteNombre(editorialDto.Nombre,id);
        // if (existeNombreMarca){
        //     throw new ArgumentException($"Ya existe una editorial con el nombre {editorialDto.Nombre}");
        // }

        //Mapeo Dto => Entidad
        editorial.Nombre = editorialDto.Nombre;

        //Persistencia objeto
        await repository.UpdateAsync(editorial);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }

    public async Task<bool> DeleteAsync(int editorialId)
    {
        var editorial = await repository.GetByIdAsync(editorialId);
        if (editorial == null){
            throw new ArgumentException($"La editorial con el id: {editorialId}, no existe");
        }

        repository.Delete(editorial);
        await repository.UnitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<EditorialDto> GetAll()
    {
        var editorialesList = repository.GetAll();

        var editorialesListDto =  from e in editorialesList
                            select new EditorialDto(){
                                Id = e.Id,
                                Nombre = e.Nombre
                            };

        return editorialesListDto.ToList();
    }

}
