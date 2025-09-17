using System.ComponentModel.DataAnnotations.Schema;
namespace BibliotecaFull.Dominio.Entidades
{
    public class Sucursales
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public int Ciudad { get; set; }
        public string? Telefono { get; set; }
        [ForeignKey("Ciudad")] public Ciudades? _Ciudad { get; set; }
    }
}
