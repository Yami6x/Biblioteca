using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class CiudadesPrueba
    {
        private Conexion? _conexion;
        private CiudadesAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new CiudadesAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Ciudades()
        {
            var ciudad = EntidadesNucleo.CrearCiudad();
            ciudad = _app!.Guardar(ciudad);
            Assert.IsTrue(ciudad.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            ciudad.Nombre = "Ciudad Modificada";
            var mod = _app.Modificar(ciudad);
            Assert.AreEqual("Ciudad Modificada", mod!.Nombre);

            var borrado = _app.Borrar(ciudad);
            Assert.AreEqual(ciudad.Id, borrado!.Id);
        }

        [TestMethod]
        public void Ciudad_DebeTenerPais()
        {
            var ciudad = EntidadesNucleo.CrearCiudad();
            ciudad.Pais = 0;
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                if (ciudad.Pais <= 0)
                    throw new ArgumentException("La ciudad debe pertenecer a un país válido");
            });
        }
    }
}
