using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class ReservasAplicacion : IReservasAplicacion
    {
        private IConexion? IConexion = null;

        public ReservasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Reservas> Listar()
        {
            return this.IConexion!.Reservas!.ToList();
        }

        public Reservas? Guardar(Reservas? entidad)
        {
            this.IConexion!.Reservas!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Reservas.");

            return entidad;
        }

        public Reservas? Modificar(Reservas? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Reservas>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Reservas? Borrar(Reservas? entidad)
        {
            this.IConexion!.Reservas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
