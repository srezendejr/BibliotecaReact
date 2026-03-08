using Biblioteca.ViewModel;

namespace Biblioteca.Repository.Interface
{
    public interface ILivroRepository
    {
        Task<bool> Alterar(Livro livro);
        Task<bool> Excluir(int id);
        Task<bool> Incluir(Livro livro);
    }
}
