using BibliotecaFull.Dominio.Entidades;
namespace BibliotecaFull.Repositorio.Interfaces
{
    public interface ICiudadesAplicacion
    {
        void Configurar(string StringConexion);
        List<Ciudades> Listar();
        Ciudades? Guardar(Ciudades? entidad);
        Ciudades? Modificar(Ciudades? entidad);
        Ciudades? Borrar(Ciudades? entidad);
    }
}
