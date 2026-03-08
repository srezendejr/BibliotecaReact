using Biblioteca.ViewModel;

namespace Biblioteca.Service.Interface
{
    public interface IGeneroService
    {
        Task<bool> Incluir(Genero genero);
        Task<bool> Excluir(int id);
        Task<bool> Existe(int id);
        Task<bool> Alterar(Genero genero);
        Task<IEnumerable<Genero>> ListaGenero();
        Task<IEnumerable<Genero>> PesquisaGeneroPorNome(string nome);
        Task<Genero> BuscaGeneroPorId(int id);

    }
}
