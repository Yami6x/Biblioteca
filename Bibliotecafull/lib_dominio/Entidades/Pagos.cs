using System.ComponentModel.DataAnnotations.Schema;
namespace BibliotecaFull.Dominio.Entidades
{
    public class Pagos
    {
        public int Id { get; set; }
        public int Multa { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string? MetodoPago { get; set; }
        [ForeignKey("Multa")] public Multas? _Multa { get; set; }
    }
}
