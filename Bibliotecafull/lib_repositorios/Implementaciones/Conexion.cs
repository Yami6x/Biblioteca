using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace BibliotecaFull.Repositorio.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(this.StringConexion))
            {
                optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }
        public DbSet<Libros>? Libros { get; set; }
        public DbSet<Autores>? Autores { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Miembros>? Miembros { get; set; }
        public DbSet<Prestamos>? Prestamos { get; set; }
        public DbSet<Editoriales>? Editoriales { get; set; }
        public DbSet<Idiomas>? Idiomas { get; set; }
        public DbSet<Paises>? Paises { get; set; }
        public DbSet<Ciudades>? Ciudades { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Cargos>? Cargos { get; set; }
        public DbSet<Sucursales>? Sucursales { get; set; }
        public DbSet<Reservas>? Reservas { get; set; }
        public DbSet<Multas>? Multas { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
    }
}
