using System.ComponentModel.DataAnnotations.Schema;
namespace BibliotecaFull.Dominio.Entidades
{
    public class Multas
    {
        public int Id { get; set; }
        public int Miembro { get; set; }
        public int Prestamo { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaImpuesta { get; set; }
        public bool Pagada { get; set; }
        [ForeignKey("Miembro")] public Miembros? _Miembro { get; set; }
        [ForeignKey("Prestamo")] public Prestamos? _Prestamo { get; set; }
    }
}
