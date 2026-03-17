using Asp.Versioning;
using Biblioteca.Service.Interface;
using Biblioteca.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        private readonly ILivroService _livroService;
        private readonly ILogger<AutorController> _logger;
        public AutorController(IAutorService autorService, 
            ILogger<AutorController> logger,
            ILivroService livroService)
        {
            _autorService = autorService;
            _logger = logger;
            _livroService = livroService;
        }
        [HttpGet("ListaAutores")]
        public async Task<IActionResult> ListaAutores()
        {
            var listaAutores = await _autorService.ListaAutor();
            return Ok(listaAutores);
        }

        [HttpGet("BuscaPorAutorPorId/{id}")]
        public async Task<IActionResult> BuscaPorAutorPorId(int id)
        {
            var autor = _autorService.BuscaAutorPorId(id);
            return Ok(autor);
        }

        [HttpPost("SalvarAutor")]
        public async Task<IActionResult> SalvarAutor(DTO.AutorDTO model)
        {
            try
            {
                var autorViewModel = new ViewModel.Autor
                {
                    Nome = model.Nome
                };
                await _autorService.Incluir(autorViewModel);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ExcluirAutor/{id}")]
        public async Task<IActionResult> ExcluirAutor(int id)
        {
            try
            {
                await _autorService.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/livrosPorAutor")]
        public async Task<IActionResult> BuscarLivrosPorAautor(int id)
        {
            try
            {
                var livros = await _livroService.LivrosPorAutor(id);
                return Ok(livros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
