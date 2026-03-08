namespace Biblioteca.Server.DTO
{
    public class LivroDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdGenero { get; set; }
        public string NomeGenero { get; set; }
        public int IdAutor { get; set; }
        public string NomeAutor { get; set; }
    }
}
