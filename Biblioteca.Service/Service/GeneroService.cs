using Biblioteca.Repository.Interface;
using Biblioteca.Service.Interface;

namespace Biblioteca.Service.Service
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository generoRepository;
        public GeneroService(IGeneroRepository generoRepository)
        {
            this.generoRepository = generoRepository;
        }
    }
}
