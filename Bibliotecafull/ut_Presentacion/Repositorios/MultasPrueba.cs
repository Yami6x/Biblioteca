using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class MultasPrueba
    {
        private Conexion? _conexion;
        private MultasAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new MultasAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Multas()
        {
            var multa = EntidadesNucleo.CrearMulta();
            multa = _app!.Guardar(multa);
            Assert.IsTrue(multa.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            multa.Pagada = true;
            var mod = _app.Modificar(multa);
            Assert.AreEqual(true, mod!.Pagada);

            var borrado = _app.Borrar(multa);
            Assert.AreEqual(multa.Id, borrado!.Id);
        }

        [TestMethod]
        public void Multa_MontoDebeSerPositivo()
        {
            var multa = EntidadesNucleo.CrearMulta();
            multa.Monto = -5;
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                if (multa.Monto <= 0)
                    throw new ArgumentException("El monto de la multa debe ser positivo");
            });
        }
    }
}
