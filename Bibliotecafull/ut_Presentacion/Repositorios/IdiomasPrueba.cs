using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class IdiomasPrueba
    {
        private Conexion? _conexion;
        private IdiomasAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new IdiomasAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Idiomas()
        {
            var idioma = EntidadesNucleo.CrearIdioma();
            idioma = _app!.Guardar(idioma);
            Assert.IsTrue(idioma.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            idioma.Nombre = "Idioma Modificado";
            var mod = _app.Modificar(idioma);
            Assert.AreEqual("Idioma Modificado", mod!.Nombre);

            var borrado = _app.Borrar(idioma);
            Assert.AreEqual(idioma.Id, borrado!.Id);
        }

        [TestMethod]
        public void Idioma_DebeTenerNombre()
        {
            var idioma = EntidadesNucleo.CrearIdioma();
            idioma.Nombre = null;
            Assert.ThrowsException<System.ArgumentNullException>(() =>
            {
                if (string.IsNullOrWhiteSpace(idioma.Nombre))
                    throw new ArgumentNullException("El idioma debe tener nombre");
            });
        }
    }
}
