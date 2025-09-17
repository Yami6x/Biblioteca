using BibliotecaFull.Dominio.Entidades;
namespace BibliotecaFull.Repositorio.Interfaces
{
    public interface IIdiomasAplicacion
    {
        void Configurar(string StringConexion);
        List<Idiomas> Listar();
        Idiomas? Guardar(Idiomas? entidad);
        Idiomas? Modificar(Idiomas? entidad);
        Idiomas? Borrar(Idiomas? entidad);
    }
}
