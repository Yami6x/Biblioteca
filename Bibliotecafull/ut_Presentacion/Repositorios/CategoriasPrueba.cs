using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class CategoriasPrueba
    {
        private Conexion? _conexion;
        private CategoriasAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new CategoriasAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Categorias()
        {
            var cat = EntidadesNucleo.CrearCategoria();
            cat = _app!.Guardar(cat);
            Assert.IsTrue(cat.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            cat.Nombre = "Categoría Modificada";
            var mod = _app.Modificar(cat);
            Assert.AreEqual("Categoría Modificada", mod!.Nombre);

            var borrado = _app.Borrar(cat);
            Assert.AreEqual(cat.Id, borrado!.Id);
        }

        [TestMethod]
        public void Categoria_DebeTenerNombre()
        {
            var cat = EntidadesNucleo.CrearCategoria();
            cat.Nombre = null;
            Assert.ThrowsException<System.ArgumentNullException>(() =>
            {
                if (string.IsNullOrWhiteSpace(cat.Nombre))
                    throw new ArgumentNullException("El nombre de la categoría es obligatorio");
            });
        }
    }
}
