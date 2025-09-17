using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class PrestamosPrueba
    {
        private Conexion? _conexion;
        private PrestamosAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new PrestamosAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Prestamos()
        {
            var prestamo = EntidadesNucleo.CrearPrestamo();
            prestamo = _app!.Guardar(prestamo);
            Assert.IsTrue(prestamo.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            prestamo.Estado = "Devuelto";
            var mod = _app.Modificar(prestamo);
            Assert.AreEqual("Devuelto", mod!.Estado);

            var borrado = _app.Borrar(prestamo);
            Assert.AreEqual(prestamo.Id, borrado!.Id);
        }

        [TestMethod]
        public void Prestamo_DebeTenerLibroYMiembro()
        {
            var prestamo = EntidadesNucleo.CrearPrestamo();
            prestamo.Libro = 0;
            prestamo.Miembro = 0;
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                if (prestamo.Libro <= 0 || prestamo.Miembro <= 0)
                    throw new ArgumentException("El préstamo debe estar asociado a un libro y a un miembro");
            });
        }
    }
}
