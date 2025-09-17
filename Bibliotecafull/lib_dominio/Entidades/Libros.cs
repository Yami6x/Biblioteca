using System.ComponentModel.DataAnnotations.Schema;
namespace BibliotecaFull.Dominio.Entidades
{
    public class Libros
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? ISBN { get; set; }
        public int Autor { get; set; }
        public int Categoria { get; set; }
        public int Editorial { get; set; }
        public int Idioma { get; set; }
        public int AnoPublicacion { get; set; }
        public int CopiasDisponibles { get; set; }
        public int Paginas { get; set; }
        [ForeignKey("Autor")] public Autores? _Autor { get; set; }
        [ForeignKey("Categoria")] public Categorias? _Categoria { get; set; }
        [ForeignKey("Editorial")] public Editoriales? _Editorial { get; set; }
        [ForeignKey("Idioma")] public Idiomas? _Idioma { get; set; }
    }
}
