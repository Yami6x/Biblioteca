using BibliotecaFull.Dominio.Entidades;
namespace BibliotecaFull.Repositorio.Interfaces
{
    public interface ILibrosAplicacion
    {
        void Configurar(string StringConexion);
        List<Libros> Listar();
        Libros? Guardar(Libros? entidad);
        Libros? Modificar(Libros? entidad);
        Libros? Borrar(Libros? entidad);
    }
}
