namespace BibliotecaFull.Dominio.Entidades
{
    public class Autores
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Biografia { get; set; }
    }
}
