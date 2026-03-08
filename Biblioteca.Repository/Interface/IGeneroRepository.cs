using Biblioteca.ViewModel;

namespace Biblioteca.Repository.Interface
{
    public interface IGeneroRepository
    {
        Task<bool> Alterar(Genero genero);
        Task<Genero> BuscaGeneroPorId(int id);
        Task<bool> Excluir(int id);
        Task<bool> Existe(int id);
        Task<bool> Incluir(Genero genero);
        Task<IEnumerable<Genero>> ListaGenero();
        Task<IEnumerable<Genero>> PesquisaGeneroPorNome(string nome);
    }
}
