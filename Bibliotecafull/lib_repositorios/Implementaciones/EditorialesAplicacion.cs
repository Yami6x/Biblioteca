using BibliotecaFull.Dominio.Entidades;
using BibliotecaFull.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaFull.Repositorio.Implementaciones
{
    public class EditorialesAplicacion : IEditorialesAplicacion
    {
        private IConexion? IConexion = null;

        public EditorialesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Editoriales> Listar()
        {
            return this.IConexion!.Editoriales!.ToList();
        }

        public Editoriales? Guardar(Editoriales? entidad)
        {
            this.IConexion!.Editoriales!.Add(entidad!);
            this.IConexion.SaveChanges();

            if (entidad!.Id == 0)
                throw new Exception("No se pudo guardar la entidad Editoriales.");

            return entidad;
        }

        public Editoriales? Modificar(Editoriales? entidad)
        {
            try
            {
                var entry = this.IConexion!.Entry<Editoriales>(entidad!);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public Editoriales? Borrar(Editoriales? entidad)
        {
            this.IConexion!.Editoriales!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}