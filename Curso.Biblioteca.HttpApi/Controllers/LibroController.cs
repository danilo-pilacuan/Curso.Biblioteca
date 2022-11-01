using Curso.Biblioteca.Application;
using Microsoft.AspNetCore.Mvc;
namespace Curso.Biblioteca.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LibroController:ControllerBase
{
    private readonly ILibroAppService libroAppService;

    public LibroController(ILibroAppService libroAppService)
    {
        this.libroAppService = libroAppService;
    }

    [HttpGet]
    public ICollection<LibroDto> GetAll()
    {

        return libroAppService.GetAll();
    }

    [HttpPost]
    public async Task<LibroDto> CreateAsync(LibroCreateUpdateDto libro)
    {

        return await libroAppService.CreateAsync(libro);

    }

    [HttpPut]
    public async Task UpdateAsync(int id, LibroCreateUpdateDto libro)
    {

        await libroAppService.UpdateAsync(id, libro);

    }

    [HttpDelete]
    public async Task<bool> DeleteAsync(int libroId)
    {

        return await libroAppService.DeleteAsync(libroId);

    }
}
