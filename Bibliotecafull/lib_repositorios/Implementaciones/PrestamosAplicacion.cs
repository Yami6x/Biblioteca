using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class PrestamosAplicacion : IPrestamosAplicacion
    {
        private IConexion? IConexion = null;

        public PrestamosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Prestamos> Listar()
        {
            return this.IConexion!.Prestamos!.ToList();
        }

        public Prestamos? Guardar(Prestamos? entidad)
        {
            this.IConexion!.Prestamos!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Prestamos.");

            return entidad;
        }

        public Prestamos? Modificar(Prestamos? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Prestamos>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Prestamos? Borrar(Prestamos? entidad)
        {
            this.IConexion!.Prestamos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}