using Asp.Versioning;
using Biblioteca.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        private readonly ILogger<AutorController> _logger;
        public AutorController(IAutorService autorService, ILogger<AutorController> logger)
        {
            _autorService = autorService;
            _logger = logger;
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
        public async Task<IActionResult>SalvarAutor(DTO.AutorDTO model)
        {
            var autorViewModel = new ViewModel.Autor
            {
                Nome = model.Nome
            };
            await _autorService.Incluir(autorViewModel);
            return Ok();
        }
    }
}
