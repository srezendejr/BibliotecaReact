using Biblioteca.ViewModel;

namespace Biblioteca.Service.Interface
{
    public interface IAutorService
    {
        Task<bool> Incluir(Autor autor);
        Task<bool> Excluir(int id);
        Task<bool> Existe(int id);
        Task<bool> Alterar(Autor autor);
        Task<IEnumerable<Autor>> ListaAutor();
        Task<IEnumerable<Autor>> PesquisaAutorPorNome(string nome);
        Task<Autor> BuscaAutorPorId(int id);
    }
}
