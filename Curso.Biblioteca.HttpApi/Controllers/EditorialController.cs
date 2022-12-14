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
    public async Task<EditorialDto> CreateAsync([FromForm] EditorialCreateUpdateDto editorial)
    {

        return await editorialAppService.CreateAsync(editorial);

    }

    [HttpPut("{id}")]
    public async Task UpdateAsync(int id, EditorialCreateUpdateDto editorial)
    {

        await editorialAppService.UpdateAsync(id, editorial);

    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteAsync(int editorialId)
    {

        return await editorialAppService.DeleteAsync(editorialId);

    }
}
