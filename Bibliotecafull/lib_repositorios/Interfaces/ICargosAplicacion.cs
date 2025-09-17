using BibliotecaFull.Dominio.Entidades;
namespace BibliotecaFull.Repositorio.Interfaces
{
    public interface ICargosAplicacion
    {
        void Configurar(string StringConexion);
        List<Cargos> Listar();
        Cargos? Guardar(Cargos? entidad);
        Cargos? Modificar(Cargos? entidad);
        Cargos? Borrar(Cargos? entidad);
    }
}
