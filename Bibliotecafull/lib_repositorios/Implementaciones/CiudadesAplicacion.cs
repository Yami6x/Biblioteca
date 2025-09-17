using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class CiudadesAplicacion : ICiudadesAplicacion
    {
        private IConexion? IConexion = null;

        public CiudadesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Ciudades> Listar()
        {
            return this.IConexion!.Ciudades!.ToList();
        }

        public Ciudades? Guardar(Ciudades? entidad)
        {
            this.IConexion!.Ciudades!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Ciudades.");

            return entidad;
        }

        public Ciudades? Modificar(Ciudades? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Ciudades>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Ciudades? Borrar(Ciudades? entidad)
        {
            this.IConexion!.Ciudades!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
