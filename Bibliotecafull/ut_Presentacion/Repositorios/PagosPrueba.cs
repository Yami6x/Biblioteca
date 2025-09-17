using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class PagosPrueba
    {
        private Conexion? _conexion;
        private PagosAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new PagosAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Pagos()
        {
            var pago = EntidadesNucleo.CrearPago();
            pago = _app!.Guardar(pago);
            Assert.IsTrue(pago.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            pago.MetodoPago = "Tarjeta";
            var mod = _app.Modificar(pago);
            Assert.AreEqual("Tarjeta", mod!.MetodoPago);

            var borrado = _app.Borrar(pago);
            Assert.AreEqual(pago.Id, borrado!.Id);
        }

        [TestMethod]
        public void Pago_MontoDebeSerPositivo()
        {
            var pago = EntidadesNucleo.CrearPago();
            pago.Monto = -10;
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                if (pago.Monto <= 0)
                    throw new ArgumentException("El monto del pago debe ser positivo");
            });
        }
    }
}
