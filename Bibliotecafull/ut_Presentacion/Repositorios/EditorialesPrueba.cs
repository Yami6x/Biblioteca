using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class EditorialesPrueba
    {
        private Conexion? _conexion;
        private EditorialesAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new EditorialesAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Editoriales()
        {
            var ed = EntidadesNucleo.CrearEditorial();
            ed = _app!.Guardar(ed);
            Assert.IsTrue(ed.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            ed.Nombre = "Editorial Modificada";
            var mod = _app.Modificar(ed);
            Assert.AreEqual("Editorial Modificada", mod!.Nombre);

            var borrado = _app.Borrar(ed);
            Assert.AreEqual(ed.Id, borrado!.Id);
        }

        [TestMethod]
        public void Editorial_DebeTenerPais()
        {
            var ed = EntidadesNucleo.CrearEditorial();
            ed.Pais = 0;
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                if (ed.Pais <= 0)
                    throw new ArgumentException("La editorial debe pertenecer a un país");
            });
        }
    }
}
