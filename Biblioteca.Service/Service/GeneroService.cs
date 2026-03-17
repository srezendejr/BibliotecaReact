using Biblioteca.Repository.Interface;
using Biblioteca.Repository.Repository;
using Biblioteca.Service.Interface;
using Biblioteca.ViewModel;
using System.Runtime.CompilerServices;

namespace Biblioteca.Service.Service
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository generoRepository;
        private readonly ILivroRepository livroRepository;
        public GeneroService(IGeneroRepository generoRepository, ILivroRepository livroRepository)
        {
            this.generoRepository = generoRepository;
            this.livroRepository = livroRepository;
        }

        public async Task<bool> Alterar(Genero genero)
        {
            ValidarGenero(genero);
            return await generoRepository.Alterar(genero);
        }

        public async Task<Genero> BuscaGeneroPorId(int id)
        {
            return await generoRepository.BuscaGeneroPorId(id);
        }

        public async Task<bool> Excluir(int id)
        {
            if (id <= 0)
                throw new Exception("Informe um código de gênero válido");
            bool bExiste = await Existe(id);
            if (!bExiste)
                throw new Exception("O gênero não existe");
            var listaLivros = await livroRepository.LivrosPorGenero(id);
            if (listaLivros.Count() > 0)
                throw new Exception("Não é possível excluir o gênero. Ele possui livros cadastrados");
            return await generoRepository.Excluir(id);

        }

        public async Task<bool> Existe(int id)
        {
            return await generoRepository.Existe(id);
        }

        public async Task<bool> Incluir(Genero genero)
        {
            ValidarGenero(genero);
            await generoRepository.Incluir(genero);
            return true;
        }

        public async Task<IEnumerable<Genero>> ListaGenero()
        {
            return await generoRepository.ListaGenero();
        }

        public async Task<IEnumerable<Genero>> PesquisaGeneroPorNome(string nome)
        {
            return await generoRepository.PesquisaGeneroPorNome(nome);
        }

        private bool ValidarGenero(Genero genero)
        {
            if (genero == null)
                throw new NullReferenceException("Gênero é nulo");

            if (string.IsNullOrWhiteSpace(genero.Nome))
                throw new Exception("Nome do gênero é obrigatório");

            return true;
        }

    }
}
