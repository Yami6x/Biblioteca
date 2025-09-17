using BibliotecaFull.Dominio.Entidades;
namespace BibliotecaFull.Repositorio.Interfaces
{
    public interface IMultasAplicacion
    {
        void Configurar(string StringConexion);
        List<Multas> Listar();
        Multas? Guardar(Multas? entidad);
        Multas? Modificar(Multas? entidad);
        Multas? Borrar(Multas? entidad);
    }
}
