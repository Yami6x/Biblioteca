using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class AutoresAplicacion : IAutoresAplicacion
    {
        private IConexion? IConexion = null;

        public AutoresAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Autores> Listar()
        {
            return this.IConexion!.Autores!.ToList();
        }

        public Autores? Guardar(Autores? entidad)
        {
            this.IConexion!.Autores!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Autores.");

            return entidad;
        }

        public Autores? Modificar(Autores? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Autores>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Autores? Borrar(Autores? entidad)
        {
            this.IConexion!.Autores!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
