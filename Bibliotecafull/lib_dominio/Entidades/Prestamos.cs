using System.ComponentModel.DataAnnotations.Schema;
namespace BibliotecaFull.Dominio.Entidades
{
    public class Prestamos
    {
        public int Id { get; set; }
        public int Libro { get; set; }
        public int Miembro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string? Estado { get; set; }
        [ForeignKey("Libro")] public Libros? _Libro { get; set; }
        [ForeignKey("Miembro")] public Miembros? _Miembro { get; set; }
    }
}
