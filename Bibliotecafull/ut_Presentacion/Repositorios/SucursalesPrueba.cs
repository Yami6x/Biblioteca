using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class SucursalesPrueba
    {
        private Conexion? _conexion;
        private SucursalesAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new SucursalesAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Sucursales()
        {
            var sucursal = EntidadesNucleo.CrearSucursal();
            sucursal = _app!.Guardar(sucursal);
            Assert.IsTrue(sucursal.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            sucursal.Nombre = "Sucursal Modificada";
            var mod = _app.Modificar(sucursal);
            Assert.AreEqual("Sucursal Modificada", mod!.Nombre);

            var borrado = _app.Borrar(sucursal);
            Assert.AreEqual(sucursal.Id, borrado!.Id);
        }

        [TestMethod]
        public void Sucursal_DebeTenerCiudad()
        {
            var sucursal = EntidadesNucleo.CrearSucursal();
            sucursal.Ciudad = 0;
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                if (sucursal.Ciudad <= 0)
                    throw new ArgumentException("La sucursal debe pertenecer a una ciudad válida");
            });
        }
    }
}

