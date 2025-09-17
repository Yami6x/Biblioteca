using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class MultasAplicacion : IMultasAplicacion
    {
        private IConexion? IConexion = null;

        public MultasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Multas> Listar()
        {
            return this.IConexion!.Multas!.ToList();
        }

        public Multas? Guardar(Multas? entidad)
        {
            this.IConexion!.Multas!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Multas.");

            return entidad;
        }

        public Multas? Modificar(Multas? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Multas>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Multas? Borrar(Multas? entidad)
        {
            this.IConexion!.Multas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}