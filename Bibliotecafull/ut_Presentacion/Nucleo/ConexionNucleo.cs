using BibliotecaFull.Repositorio.Implementaciones;

namespace BibliotecaFull.Test.Nucleo
{
    public static class ConexionNucleo
    {
        public static Conexion Crear()
        {
            var db = new Conexion();
            db.StringConexion = Configuracion.StringConexion;
            db.Database.EnsureCreated(); // Crea la BD si no existe
            return db;
        }
    }
}
