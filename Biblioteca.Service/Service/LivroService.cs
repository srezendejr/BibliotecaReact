using Biblioteca.Repository.Interface;
using Biblioteca.Service.Interface;

namespace Biblioteca.Service.Service
{
    public class LivroService : ILivroInterface
    {
        private ILivroRepository livroRepository;
        public LivroService(ILivroRepository livroRepository)
        {
            this.livroRepository = livroRepository;
        }
    }
}
