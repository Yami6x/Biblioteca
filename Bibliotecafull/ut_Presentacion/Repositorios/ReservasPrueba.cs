using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class ReservasPrueba
    {
        private Conexion? _conexion;
        private ReservasAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new ReservasAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Reservas()
        {
            var reserva = EntidadesNucleo.CrearReserva();
            reserva = _app!.Guardar(reserva);
            Assert.IsTrue(reserva.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            reserva.Estado = "Cancelada";
            var mod = _app.Modificar(reserva);
            Assert.AreEqual("Cancelada", mod!.Estado);

            var borrado = _app.Borrar(reserva);
            Assert.AreEqual(reserva.Id, borrado!.Id);
        }

        [TestMethod]
        public void Reserva_DebeTenerLibroYMiembro()
        {
            var reserva = EntidadesNucleo.CrearReserva();
            reserva.Libro = 0;
            reserva.Miembro = 0;
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                if (reserva.Libro <= 0 || reserva.Miembro <= 0)
                    throw new ArgumentException("La reserva debe estar asociada a un libro y a un miembro");
            });
        }
    }
}
