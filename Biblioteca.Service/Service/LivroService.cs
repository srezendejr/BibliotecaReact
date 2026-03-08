using Biblioteca.Repository.Interface;
using Biblioteca.Service.Interface;
using Biblioteca.ViewModel;

namespace Biblioteca.Service.Service
{
    public class LivroService : ILivroInterface
    {
        private ILivroRepository livroRepository;
        public LivroService(ILivroRepository livroRepository)
        {
            this.livroRepository = livroRepository;
        }
        private bool ValidaLivro(Livro livro)
        {
            if (livro == null)
                throw new NullReferenceException("Livro não pode ser nulo");

            if (string.IsNullOrEmpty(livro.Nome))
                throw new Exception("Informe o nome do livro");

            if (livro.IdGenero <= 0)
                throw new Exception("Informe o gênero do livro");

            if (livro.IdAutor <= 0)
                throw new Exception("Informe o autor do livro");

            return true;
        }
        public async Task<bool> Incluir(Livro livro)
        {
            ValidaLivro(livro);
            return await livroRepository.Incluir(livro);
        }

        public async Task<bool?> Alterar(Livro livro)
        {
            ValidaLivro(livro);
            return await livroRepository.Alterar(livro);
        }

        public async Task<bool> Excluir(int id)
        {
            if (id <= 0)
                throw new Exception("Informe o código do livro");
            return await livroRepository.Excluir(id);
        }
    }
}
