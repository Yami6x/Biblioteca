using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private IConexion? IConexion = null;

        public PagosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Pagos> Listar()
        {
            return this.IConexion!.Pagos!.ToList();
        }

        public Pagos? Guardar(Pagos? entidad)
        {
            this.IConexion!.Pagos!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Pagos.");

            return entidad;
        }

        public Pagos? Modificar(Pagos? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Pagos>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Pagos? Borrar(Pagos? entidad)
        {
            this.IConexion!.Pagos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
