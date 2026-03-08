using Biblioteca.Repository.Interface;
using Biblioteca.Service.Service;
using Biblioteca.ViewModel;
using Moq;

namespace Biblioteca.Test;

[TestClass]
public class LivroTest
{
    private LivroService _livroService;
    private Mock<ILivroRepository> _livroRepositoryMock;
    [TestInitialize]
    public void Setup()
    {
        _livroRepositoryMock = new Mock<ILivroRepository>();
        _livroService = new LivroService(_livroRepositoryMock.Object);
    }
    [TestMethod]
    public async Task InserirLivroNulo()
    {
        var ex = await Assert.ThrowsAsync<NullReferenceException>(() =>
                   _livroService.Incluir(null)
         );
        Assert.AreEqual("Livro não pode ser nulo", ex.Message);
    }

    [TestMethod]
    public async Task InserirLivroNomeNulo()
    {
        Livro livro = new Livro() { 
            Id = 0,
            IdAutor = 1,
            IdGenero = 1,
            Nome = string.Empty
        };
        var ex = await Assert.ThrowsAsync<Exception>(() =>
                   _livroService.Incluir(livro)
         );
        Assert.AreEqual("Informe o nome do livro", ex.Message);
    }

    [TestMethod]
    public async Task InserirLivroSemGenero()
    {
        Livro livro = new Livro()
        {
            Id = 0,
            IdAutor = 1,
            IdGenero = 0,
            Nome = "Os Sertões"
        };
        var ex = await Assert.ThrowsAsync<Exception>(() =>
                   _livroService.Incluir(livro)
         );
        Assert.AreEqual("Informe o gênero do livro", ex.Message);
    }

    [TestMethod]
    public async Task InserirLivroSemAutor()
    {
        Livro livro = new Livro()
        {
            Id = 0,
            IdAutor = 0,
            IdGenero = 1,
            Nome = "Os Sertões"
        };
        var ex = await Assert.ThrowsAsync<Exception>(() =>
                   _livroService.Incluir(livro)
         );
        Assert.AreEqual("Informe o autor do livro", ex.Message);
    }

    [TestMethod]
    public async Task IncluirLivro()
    {
        Livro livro = new Livro()
        {
            Id = 0,
            IdAutor = 1,
            IdGenero = 1,
            Nome = "Os Sertões"
        };

        _livroRepositoryMock
            .Setup(x => x.Incluir(It.IsAny<Livro>()))
            .ReturnsAsync(true);

        var resultado = await _livroService.Incluir(livro);

        Assert.IsTrue(resultado);
    }

    [TestMethod]
    public async Task AlterarLivro()
    {
        Livro livro = new Livro()
        {
            Id = 1,
            IdAutor = 1,
            IdGenero = 1,
            Nome = "Dom Casmurro"
        };

        _livroRepositoryMock
            .Setup(x => x.Alterar(It.IsAny<Livro>()))
            .ReturnsAsync(true);

        var resultado = await _livroService.Alterar(livro);

        Assert.IsTrue(resultado);

    }

    [TestMethod]
    public async Task ExcluirLivroSemCodigo()
    {
        var ex = await Assert.ThrowsAsync<Exception>(() =>
                          _livroService.Excluir(0)
                );
        Assert.AreEqual("Informe o código do livro", ex.Message);
    }

}
