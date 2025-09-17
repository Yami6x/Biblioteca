using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class LibrosAplicacion : ILibrosAplicacion
    {
        private IConexion? IConexion = null;

        public LibrosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Libros> Listar()
        {
            return this.IConexion!.Libros!.ToList();
        }

        public Libros? Guardar(Libros? entidad)
        {
            this.IConexion!.Libros!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Libros.");

            return entidad;
        }

        public Libros? Modificar(Libros? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Libros>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Libros? Borrar(Libros? entidad)
        {
            this.IConexion!.Libros!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}