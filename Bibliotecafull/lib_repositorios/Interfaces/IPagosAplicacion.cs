using BibliotecaFull.Dominio.Entidades;
namespace BibliotecaFull.Repositorio.Interfaces
{
    public interface IPagosAplicacion
    {
        void Configurar(string StringConexion);
        List<Pagos> Listar();
        Pagos? Guardar(Pagos? entidad);
        Pagos? Modificar(Pagos? entidad);
        Pagos? Borrar(Pagos? entidad);
    }
}
