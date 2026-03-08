using Biblioteca.Repository.Interface;
using Biblioteca.Service.Interface;
using Biblioteca.Service.Service;
using Biblioteca.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Biblioteca.Test
{
    [TestClass]
    public sealed class AutorTest
    {
        private IAutorService _autorService;
        private Mock<IAutorRepository> _autorRepositoryMock;
        [TestInitialize]
        public void Setup()
        {
            _autorRepositoryMock = new Mock<IAutorRepository>();
            _autorService = new AutorService(_autorRepositoryMock.Object);
        }

        [TestMethod]
        public async Task IncluirAutorNullo()
        {
            var ex = await Assert.ThrowsAsync<NullReferenceException>(() =>
                      _autorService.Incluir(null)
            );
            Assert.AreEqual("Autor é nulo", ex.Message);
        }

        [TestMethod]
        public async Task IncluirAutorComNomeVazio()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() =>
                     _autorService.Incluir(new ViewModel.Autor())
                     );
            Assert.AreEqual("Nome do autor é obrigatório", ex.Message);
        }

        [TestMethod]
        public async Task IncluirAutor()
        {
            var autor = new ViewModel.Autor { Nome = "Machado de Assis" };

            _autorRepositoryMock
                .Setup(x => x.Incluir(It.IsAny<ViewModel.Autor>()))
                .ReturnsAsync(true);

            var resultado = await _autorService.Incluir(autor);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task AutorExiste()
        {
            _autorRepositoryMock
                .Setup(x => x.Existe(It.IsAny<int>()))
                .ReturnsAsync(true);

            var resultado = await _autorService.Existe(1);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public async Task AutorNaoExiste()
        {
            _autorRepositoryMock
                .Setup(x => x.Existe(It.IsAny<int>()))
                .ReturnsAsync(false);

            var resultado = await _autorService.Existe(1);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public async Task ExcluirAutor()
        {
            _autorRepositoryMock
                .Setup(x => x.Excluir(It.IsAny<int>()))
                .ReturnsAsync(true);

            var resultado = await _autorService.Excluir(1);

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public async Task ExcluirAutorSemCodigoValido()
        {
            var ex = await Assert.ThrowsAsync<Exception>(() =>
                      _autorService.Excluir(0)
            );
            Assert.AreEqual("Informe um código de autor válido", ex.Message);
        }

        [TestMethod]
        public async Task AterarAutor()
        {
            var autor = new ViewModel.Autor { Id = 1, Nome = "Machado de Assis" };

            _autorRepositoryMock
                .Setup(x => x.Alterar(It.IsAny<ViewModel.Autor>()))
                .ReturnsAsync(true);

            var resultado = await _autorService.Alterar(autor);

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public async Task BuscaAutorPorId()
        {
            _autorRepositoryMock
                .Setup(x => x.BuscaAutorPorId(It.IsAny<int>()))
                .ReturnsAsync(new Autor());

            var resultado = await _autorService.BuscaAutorPorId(1);

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task ListaAutor()
        {
            _autorRepositoryMock
                .Setup(x => x.ListaAutor())
                .ReturnsAsync(new List<Autor>());

            var resultado = await _autorService.ListaAutor();

            Assert.IsNotNull(resultado);

        }

        [TestMethod]
        public async Task PesquisaAutorPorNome()
        {
            _autorRepositoryMock
                .Setup(x => x.PesquisaAutorPorNome(It.IsAny<string>()))
                .ReturnsAsync(new List<Autor>());

            var resultado = await _autorService.PesquisaAutorPorNome("Machado de Assis");

            Assert.IsNotNull(resultado);

        }
    }
}
