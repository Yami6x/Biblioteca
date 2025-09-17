using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class IdiomasAplicacion : IIdiomasAplicacion
    {
        private IConexion? IConexion = null;

        public IdiomasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Idiomas> Listar()
        {
            return this.IConexion!.Idiomas!.ToList();
        }

        public Idiomas? Guardar(Idiomas? entidad)
        {
            this.IConexion!.Idiomas!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Idiomas.");

            return entidad;
        }

        public Idiomas? Modificar(Idiomas? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Idiomas>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Idiomas? Borrar(Idiomas? entidad)
        {
            this.IConexion!.Idiomas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
