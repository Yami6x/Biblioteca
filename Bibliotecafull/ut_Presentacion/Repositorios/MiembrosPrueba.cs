using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class MiembrosPrueba
    {
        private Conexion? _conexion;
        private MiembrosAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new MiembrosAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Miembros()
        {
            var miembro = EntidadesNucleo.CrearMiembro();
            miembro = _app!.Guardar(miembro);
            Assert.IsTrue(miembro.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            miembro.Nombre = "Miembro Modificado";
            var mod = _app.Modificar(miembro);
            Assert.AreEqual("Miembro Modificado", mod!.Nombre);

            var borrado = _app.Borrar(miembro);
            Assert.AreEqual(miembro.Id, borrado!.Id);
        }

        [TestMethod]
        public void Miembro_DebeTenerIdentificacion()
        {
            var miembro = EntidadesNucleo.CrearMiembro();
            miembro.Identificacion = null;
            Assert.ThrowsException<System.ArgumentNullException>(() =>
            {
                if (string.IsNullOrWhiteSpace(miembro.Identificacion))
                    throw new ArgumentNullException("El miembro debe tener identificación");
            });
        }
    }
}
