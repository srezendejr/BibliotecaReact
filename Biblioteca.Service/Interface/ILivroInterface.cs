using Biblioteca.ViewModel;

namespace Biblioteca.Service.Interface
{
    public interface ILivroService
    {
        Task<bool> Excluir(int id);
        Task<bool?> Alterar(Livro livro);
        Task<bool> Incluir(Livro livro);
        Task<IEnumerable<Livro>> ListaLivros();
        Task<Livro> BuscaLivroPorId(int id);
        Task<bool> Existe(int id);
        Task<IEnumerable<Livro>> LivrosPorAutor(int idAutor);
        Task<IEnumerable<Livro>> LivrosPorGenero(int idGenero);
    }
}
