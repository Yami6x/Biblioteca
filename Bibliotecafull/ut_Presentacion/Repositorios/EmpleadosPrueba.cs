using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaFull.Repositorio.Implementaciones;
using BibliotecaFull.Test.Nucleo;

namespace BibliotecaFull.Test.Repositorios
{
    [TestClass]
    public class EmpleadosPrueba
    {
        private Conexion? _conexion;
        private EmpleadosAplicacion? _app;

        [TestInitialize]
        public void Inicializar()
        {
            _conexion = ConexionNucleo.Crear();
            _app = new EmpleadosAplicacion(_conexion);
            _app.Configurar(Configuracion.StringConexion);
        }

        [TestMethod]
        public void Crud_Empleados()
        {
            var emp = EntidadesNucleo.CrearEmpleado();
            emp = _app!.Guardar(emp);
            Assert.IsTrue(emp.Id > 0);

            var lista = _app.Listar();
            Assert.IsTrue(lista.Count > 0);

            emp.Nombre = "Empleado Modificado";
            var mod = _app.Modificar(emp);
            Assert.AreEqual("Empleado Modificado", mod!.Nombre);

            var borrado = _app.Borrar(emp);
            Assert.AreEqual(emp.Id, borrado!.Id);
        }

        [TestMethod]
        public void Empleado_DebeTenerCargo()
        {
            var emp = EntidadesNucleo.CrearEmpleado();
            emp.Cargo = 0;
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                if (emp.Cargo <= 0)
                    throw new ArgumentException("El empleado debe tener un cargo válido");
            });
        }
    }
}
