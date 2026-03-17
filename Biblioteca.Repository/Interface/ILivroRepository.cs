using Biblioteca.ViewModel;

namespace Biblioteca.Repository.Interface
{
    public interface ILivroRepository
    {
        Task<bool> Alterar(Livro livro);
        Task<Livro> BuscaLivroPorId(int id);
        Task<bool> Excluir(int id);
        Task<bool> Incluir(Livro livro);
        Task<IEnumerable<Livro>> ListarLivros();
        Task<IEnumerable<Livro>> LivrosPorAutor(int idAutor);
        Task<IEnumerable<Livro>> LivrosPorGenero(int idGenero);
        Task<bool> Existe(int id);
    }
}
