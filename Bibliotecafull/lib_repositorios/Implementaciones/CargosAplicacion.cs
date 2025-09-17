using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class CargosAplicacion : ICargosAplicacion
    {
        private IConexion? IConexion = null;

        public CargosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Cargos> Listar()
        {
            return this.IConexion!.Cargos!.ToList();
        }

        public Cargos? Guardar(Cargos? entidad)
        {
            this.IConexion!.Cargos!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Cargos.");

            return entidad;
        }

        public Cargos? Modificar(Cargos? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Cargos>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Cargos? Borrar(Cargos? entidad)
        {
            this.IConexion!.Cargos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
