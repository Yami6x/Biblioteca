using BibliotecaFull.Dominio.Entidades;
namespace BibliotecaFull.Repositorio.Interfaces
{
    public interface IPrestamosAplicacion
    {
        void Configurar(string StringConexion);
        List<Prestamos> Listar();
        Prestamos? Guardar(Prestamos? entidad);
        Prestamos? Modificar(Prestamos? entidad);
        Prestamos? Borrar(Prestamos? entidad);
    }
}
