using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class CargosPrueba
    {
        private Conexion? _conexion;
        private CargosAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new CargosAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Cargos()
        {
            var cargo = EntidadesNucleo.CrearCargo();
            cargo = _app!.Guardar(cargo);
            Assert.IsTrue(cargo.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            cargo.Nombre = "Cargo Modificado";
            var mod = _app.Modificar(cargo);
            Assert.AreEqual("Cargo Modificado", mod!.Nombre);

            var borrado = _app.Borrar(cargo);
            Assert.AreEqual(cargo.Id, borrado!.Id);
        }

        [TestMethod]
        public void Cargo_DebeTenerNombre()
        {
            var cargo = EntidadesNucleo.CrearCargo();
            cargo.Nombre = null;
            Assert.ThrowsException<System.ArgumentNullException>(() =>
            {
                if (string.IsNullOrWhiteSpace(cargo.Nombre))
                    throw new ArgumentNullException("El cargo debe tener nombre");
            });
        }
    }
}
