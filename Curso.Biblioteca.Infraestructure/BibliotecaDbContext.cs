using Curso.Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.Biblioteca.Infraestructure;

public class BibliotecaDbContext:DbContext,IUnitOfWork
{
    public DbSet<Autor> Autores {get;set;}
    public DbSet<Editorial> Editoriales {get;set;}
    public DbSet<Libro> Libros {get;set;}

    public string DbPath {get;set;}

    public BibliotecaDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        //DbPath = Path.Join(path, "biblioteca.v3.db");
        DbPath = Path.Combine(Directory.GetCurrentDirectory(), "../Curso.Biblioteca.HttpApi/baseBiblioteca.sqlite");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
