using BibliotecaFull.Dominio.Entidades;
namespace BibliotecaFull.Repositorio.Interfaces
{
    public interface IReservasAplicacion
    {
        void Configurar(string StringConexion);
        List<Reservas> Listar();
        Reservas? Guardar(Reservas? entidad);
        Reservas? Modificar(Reservas? entidad);
        Reservas? Borrar(Reservas? entidad);
    }
}
