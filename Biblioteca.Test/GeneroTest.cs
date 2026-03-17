using Biblioteca.Repository.Interface;
using Biblioteca.Service.Interface;
using Biblioteca.Service.Service;
using Biblioteca.ViewModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Test
{
    [TestClass]
    public class GeneroTest
    {
        private IGeneroService _generoService;
        private Mock<IGeneroRepository> _generoRepositoryMock;
        private Mock<ILivroRepository> _livroRepositoryMock;
        [TestInitialize]
        public void Setup()
        {
            _generoRepositoryMock = new Mock<IGeneroRepository>();
            _livroRepositoryMock = new Mock<ILivroRepository>();
            _generoService = new GeneroService(_generoRepositoryMock.Object, _livroRepositoryMock.Object);
        }

        [TestMethod]
        public async Task IncluirGeneroNullo()
        {
            var ex = await Assert.ThrowsAsync<NullReferenceException>(() =>
                      _generoService.Incluir(null)
            );
            Assert.AreEqual("Gênero é nulo", ex.Message);
        }

        [TestMethod]
        public async Task IncluirGeneroComNomeVazio()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() =>
                     _generoService.Incluir(new ViewModel.Genero())
                     );
            Assert.AreEqual("Nome do gênero é obrigatório", ex.Message);
        }

        [TestMethod]
        public async Task IncluirGenero()
        {
            var Genero = new ViewModel.Genero { Nome = "Machado de Assis" };

            _generoRepositoryMock
                .Setup(x => x.Incluir(It.IsAny<ViewModel.Genero>()))
                .ReturnsAsync(true);

            var resultado = await _generoService.Incluir(Genero);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task GeneroExiste()
        {
            _generoRepositoryMock
                .Setup(x => x.Existe(It.IsAny<int>()))
                .ReturnsAsync(true);

            var resultado = await _generoService.Existe(1);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task GeneroNaoExiste()
        {
            _generoRepositoryMock
                .Setup(x => x.Existe(It.IsAny<int>()))
                .ReturnsAsync(false);

            var resultado = await _generoService.Existe(1);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public async Task ExcluirGenero()
        {
            _generoRepositoryMock
                .Setup(x => x.Excluir(It.IsAny<int>()))
                .ReturnsAsync(true);

            var resultado = await _generoService.Excluir(1);

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public async Task ExcluirGeneroSemCodigoValido()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() =>
                      _generoService.Excluir(0)
            );
            Assert.AreEqual("Informe um código de gênero válido", ex.Message);
        }

        [TestMethod]
        public async Task AterarGenero()
        {
            var Genero = new ViewModel.Genero { Id = 1, Nome = "Machado de Assis" };

            _generoRepositoryMock
                .Setup(x => x.Alterar(It.IsAny<ViewModel.Genero>()))
                .ReturnsAsync(true);

            var resultado = await _generoService.Alterar(Genero);

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public async Task BuscaGeneroPorId()
        {
            _generoRepositoryMock
                .Setup(x => x.BuscaGeneroPorId(It.IsAny<int>()))
                .ReturnsAsync(new Genero());

            var resultado = await _generoService.BuscaGeneroPorId(1);

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task ListaGenero()
        {
            _generoRepositoryMock
                .Setup(x => x.ListaGenero())
                .ReturnsAsync(new List<Genero>());

            var resultado = await _generoService.ListaGenero();

            Assert.IsNotNull(resultado);

        }

        [TestMethod]
        public async Task PesquisaGeneroPorNome()
        {
            _generoRepositoryMock
                .Setup(x => x.PesquisaGeneroPorNome(It.IsAny<string>()))
                .ReturnsAsync(new List<Genero>());

            var resultado = await _generoService.PesquisaGeneroPorNome("Machado de Assis");

            Assert.IsNotNull(resultado);

        }
    }
}
