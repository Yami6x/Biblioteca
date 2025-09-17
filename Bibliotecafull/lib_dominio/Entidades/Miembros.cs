namespace BibliotecaFull.Dominio.Entidades
{
    public class Miembros
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

