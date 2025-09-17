using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class PaisesPrueba
    {
        private Conexion? _conexion;
        private PaisesAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new PaisesAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Paises()
        {
            var pais = EntidadesNucleo.CrearPais();
            pais = _app!.Guardar(pais);
            Assert.IsTrue(pais.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            pais.Nombre = "País Modificado";
            var mod = _app.Modificar(pais);
            Assert.AreEqual("País Modificado", mod!.Nombre);

            var borrado = _app.Borrar(pais);
            Assert.AreEqual(pais.Id, borrado!.Id);
        }

        [TestMethod]
        public void Pais_DebeTenerNombre()
        {
            var pais = EntidadesNucleo.CrearPais();
            pais.Nombre = null;
            Assert.ThrowsException<System.ArgumentNullException>(() =>
            {
                if (string.IsNullOrWhiteSpace(pais.Nombre))
                    throw new ArgumentNullException("El país debe tener nombre");
            });
        }
    }
}
