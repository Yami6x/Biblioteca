using BibliotecaFull.Dominio.Entidades;
namespace BibliotecaFull.Repositorio.Interfaces
{
    public interface IMiembrosAplicacion
    {
        void Configurar(string StringConexion);
        List<Miembros> Listar();
        Miembros? Guardar(Miembros? entidad);
        Miembros? Modificar(Miembros? entidad);
        Miembros? Borrar(Miembros? entidad);
    }
}
