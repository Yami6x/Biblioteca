using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class PaisesAplicacion : IPaisesAplicacion
    {
        private IConexion? IConexion = null;

        public PaisesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Paises> Listar()
        {
            return this.IConexion!.Paises!.ToList();
        }

        public Paises? Guardar(Paises? entidad)
        {
            this.IConexion!.Paises!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Paises.");

            return entidad;
        }

        public Paises? Modificar(Paises? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Paises>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Paises? Borrar(Paises? entidad)
        {
            this.IConexion!.Paises!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}