using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class MiembrosAplicacion : IMiembrosAplicacion
    {
        private IConexion? IConexion = null;

        public MiembrosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Miembros> Listar()
        {
            return this.IConexion!.Miembros!.ToList();
        }

        public Miembros? Guardar(Miembros? entidad)
        {
            this.IConexion!.Miembros!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Miembros.");

            return entidad;
        }

        public Miembros? Modificar(Miembros? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Miembros>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Miembros? Borrar(Miembros? entidad)
        {
            this.IConexion!.Miembros!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}