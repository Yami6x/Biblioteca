using System.ComponentModel.DataAnnotations.Schema;
namespace BibliotecaFull.Dominio.Entidades
{
    public class Ciudades
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Pais { get; set; }
        [ForeignKey("Pais")] public Paises? _Pais { get; set; }
    }
}
