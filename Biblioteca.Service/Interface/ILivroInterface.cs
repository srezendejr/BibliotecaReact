using Biblioteca.ViewModel;

namespace Biblioteca.Service.Interface
{
    public interface ILivroInterface
    {
        Task<bool> Excluir(int id);
        Task<bool?> Alterar(Livro livro);
        Task<bool> Incluir(Livro livro);
    }
}
