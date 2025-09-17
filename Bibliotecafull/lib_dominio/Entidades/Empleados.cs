using System.ComponentModel.DataAnnotations.Schema;
namespace BibliotecaFull.Dominio.Entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public int Cargo { get; set; }
        public int Sucursal { get; set; }
        [ForeignKey("Cargo")] public Cargos? _Cargo { get; set; }
        [ForeignKey("Sucursal")] public Sucursales? _Sucursal { get; set; }
    }
}
