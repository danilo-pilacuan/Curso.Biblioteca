using Curso.Biblioteca.Application;
using Microsoft.AspNetCore.Mvc;
namespace Curso.Biblioteca.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EditorialController:ControllerBase
{
    private readonly IEditorialAppService editorialAppService;

    public EditorialController(IEditorialAppService editorialAppService)
    {
        this.editorialAppService = editorialAppService;
    }

    [HttpGet]
    public ICollection<EditorialDto> GetAll()
    {

        return editorialAppService.GetAll();
    }

    [HttpPost]
    public async Task<EditorialDto> CreateAsync(EditorialCreateUpdateDto editorial)
    {

        return await editorialAppService.CreateAsync(editorial);

    }

    [HttpPut]
    public async Task UpdateAsync(int id, EditorialCreateUpdateDto editorial)
    {

        await editorialAppService.UpdateAsync(id, editorial);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int editorialId)
    {

        return await editorialAppService.DeleteAsync(editorialId);

    }
}
