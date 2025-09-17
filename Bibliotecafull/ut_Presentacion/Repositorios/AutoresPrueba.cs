using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;
using BibliotecaFull.Dominio.Entidades;


namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class AutoresPrueba
    {
        private Conexion? _conexion;
        private AutoresAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new AutoresAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Autores()
        {
            var autor = EntidadesNucleo.CrearAutor();
            autor = _app!.Guardar(autor);
            Assert.IsTrue(autor.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            autor.Nombre = "Autor Modificado";
            var mod = _app.Modificar(autor);
            Assert.AreEqual("Autor Modificado", mod!.Nombre);

            var borrado = _app.Borrar(autor);
            Assert.AreEqual(autor.Id, borrado!.Id);
        }

        [TestMethod]
        public void Autor_DebeTenerNombre()
        {
            var autor = EntidadesNucleo.CrearAutor();
            autor.Nombre = null;
            Assert.ThrowsException<System.ArgumentNullException>(() =>
            {
                if (string.IsNullOrWhiteSpace(autor.Nombre))
                    throw new ArgumentNullException("El nombre del autor es obligatorio");
            });
        }
    }
}
