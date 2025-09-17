using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class EmpleadosAplicacion : IEmpleadosAplicacion
    {
        private IConexion? IConexion = null;

        public EmpleadosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Empleados> Listar()
        {
            return this.IConexion!.Empleados!.ToList();
        }

        public Empleados? Guardar(Empleados? entidad)
        {
            this.IConexion!.Empleados!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Empleados.");

            return entidad;
        }

        public Empleados? Modificar(Empleados? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Empleados>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Empleados? Borrar(Empleados? entidad)
        {
            this.IConexion!.Empleados!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}