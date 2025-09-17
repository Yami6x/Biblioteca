using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class LibrosPrueba
    {
        private Conexion? _conexion;
        private LibrosAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new LibrosAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Libros()
        {
            var libro = EntidadesNucleo.CrearLibro();
            libro = _app!.Guardar(libro);
            Assert.IsTrue(libro.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            libro.Titulo = "Libro Modificado";
            var mod = _app.Modificar(libro);
            Assert.AreEqual("Libro Modificado", mod!.Titulo);

            var borrado = _app.Borrar(libro);
            Assert.AreEqual(libro.Id, borrado!.Id);
        }

        [TestMethod]
        public void Libro_DebeTenerISBN()
        {
            var libro = EntidadesNucleo.CrearLibro();
            libro.ISBN = null;
            Assert.ThrowsException<System.ArgumentNullException>(() =>
            {
                if (string.IsNullOrWhiteSpace(libro.ISBN))
                    throw new ArgumentNullException("El libro debe tener un ISBN");
            });
        }
    }
}
