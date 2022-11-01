using Curso.Biblioteca.Application;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AutorController:ControllerBase
{
    private readonly IAutorAppService autorAppService;

    public AutorController(IAutorAppService autorAppService)
    {
        this.autorAppService = autorAppService;
    }

    [HttpGet]
    public ICollection<AutorDto> GetAll()
    {
        
        return autorAppService.GetAll();
    }

    [HttpPost]
    public async Task<AutorDto> CreateAsync([FromForm] AutorCreateUpdateDto autor)
    {

        return await autorAppService.CreateAsync(autor);

    }

    [HttpPut("{id}")]
    public async Task UpdateAsync(int id, [FromForm] AutorCreateUpdateDto autor)
    {

        await autorAppService.UpdateAsync(id, autor);

    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteAsync(int autorId)
    {

        return await autorAppService.DeleteAsync(autorId);

    }
}
