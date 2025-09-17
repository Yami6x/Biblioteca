using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class SucursalesAplicacion : ISucursalesAplicacion
    {
        private IConexion? IConexion = null;

        public SucursalesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Sucursales> Listar()
        {
            return this.IConexion!.Sucursales!.ToList();
        }

        public Sucursales? Guardar(Sucursales? entidad)
        {
            this.IConexion!.Sucursales!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Sucursales.");

            return entidad;
        }

        public Sucursales? Modificar(Sucursales? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Sucursales>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Sucursales? Borrar(Sucursales? entidad)
        {
            this.IConexion!.Sucursales!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
