using Biblioteca.Repository.Interface;
using Biblioteca.Service.Interface;
using Biblioteca.ViewModel;

namespace Biblioteca.Service.Service
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<bool> Alterar(Autor autor)
        {
            ValidarAutor(autor);
            return await _autorRepository.Alterar(autor);
        }

        public async Task<Autor> BuscaAutorPorId(int id)
        {
            return await _autorRepository.BuscaAutorPorId(id); 
        }

        public async Task<bool> Excluir(int id)
        {
            if (id <= 0)
                throw new Exception("Informe um código de autor válido");
            return await _autorRepository.Excluir(id);
        }

        public Task<bool> Existe(int id)
        {
            return _autorRepository.Existe(id);
        }

        public async Task<bool> Incluir(Autor autor)
        {
            ValidarAutor(autor);
            bool retorno = await _autorRepository.Incluir(autor);
            return retorno;
        }

        public async Task<IEnumerable<Autor>> ListaAutor()
        {
            return await _autorRepository.ListaAutor();
        }

        public async Task<IEnumerable<Autor>> PesquisaAutorPorNome(string nome)
        {
            return await _autorRepository.PesquisaAutorPorNome(nome);
        }

        private bool ValidarAutor(Autor autor)
        {
            if (autor == null)
                throw new NullReferenceException("Autor é nulo");

            if (string.IsNullOrWhiteSpace(autor.Nome))
                throw new Exception("Nome do autor é obrigatório");

            return true;
        }
    }
}
