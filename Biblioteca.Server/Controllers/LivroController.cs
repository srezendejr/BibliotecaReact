using Asp.Versioning;
using Biblioteca.Service.Interface;
using Biblioteca.Service.Service;
using Biblioteca.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILogger<LivroController> _logger;
        private readonly ILivroService _livroService;
        public LivroController(ILivroService livroService, ILogger<LivroController> logger)
        {
            _livroService = livroService;
            _logger = logger;
        }
        [HttpGet("ListaLivros")]
        public async Task<IActionResult> ListaLivros()
        {
            var listaGeneros = await _livroService.ListaLivros();
            return Ok(listaGeneros);
        }

        [HttpGet("BuscaLivroPorId/{id}")]
        public async Task<IActionResult> BuscaLivroPorId(int id)
        {
            var livro = await _livroService.BuscaLivroPorId(id);
            return Ok(livro);
        }

        [HttpPost("SalvarLivro")]
        public async Task<IActionResult> SalvarLivro(DTO.LivroDTO livro)
        {
            Livro livroNOvo = new Livro
            {
                Id = livro.Id,
                IdAutor = livro.IdAutor,
                IdGenero = livro.IdGenero,
                Nome = livro.Nome,
            };
            await _livroService.Incluir(livroNOvo);
            return Ok();
        }
        [HttpDelete("ExcluirLivro/{id}")]
        public async Task<IActionResult> ExcluirLivro(int id)
        {
            await _livroService.Excluir(id);
            return Ok();
        }

    }
}
