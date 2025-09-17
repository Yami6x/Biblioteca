// Make sure the namespace and class exist in your project
using BibliotecaFull.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace BibliotecaFull.Repositorio.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        DbSet<Libros>? Libros { get; set; }
        DbSet<Autores>? Autores { get; set; }
        DbSet<Categorias>? Categorias { get; set; }
        DbSet<Miembros>? Miembros { get; set; }
        DbSet<Prestamos>? Prestamos { get; set; }
        DbSet<Editoriales>? Editoriales { get; set; }
        DbSet<Idiomas>? Idiomas { get; set; }
        DbSet<Paises>? Paises { get; set; }
        DbSet<Ciudades>? Ciudades { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Cargos>? Cargos { get; set; }
        DbSet<Sucursales>? Sucursales { get; set; }
        DbSet<Reservas>? Reservas { get; set; }
        DbSet<Multas>? Multas { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}


