using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class CategoriasAplicacion : ICategoriasAplicacion
    {
        private IConexion? IConexion = null;

        public CategoriasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Categorias> Listar()
        {
            return this.IConexion!.Categorias!.ToList();
        }

        public Categorias? Guardar(Categorias? entidad)
        {
            this.IConexion!.Categorias!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Categorias.");

            return entidad;
        }

        public Categorias? Modificar(Categorias? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Categorias>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Categorias? Borrar(Categorias? entidad)
        {
            this.IConexion!.Categorias!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
