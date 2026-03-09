using Asp.Versioning;
using Biblioteca.Service.Interface;
using Biblioteca.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly ILogger<GeneroController> _loger;
        private readonly IGeneroService _generoService;
        public GeneroController(IGeneroService generoService, ILogger<GeneroController> logger)
        {
            _generoService = generoService;
            _loger = logger;
        }

        [HttpGet("ListaGeneros")]
        public async Task<IActionResult> ListaGeneros()
        {
            var listaGeneros = await _generoService.ListaGenero();
            return Ok(listaGeneros);
        }

        [HttpGet("BuscaGeneroPorId/{id}")]
        public async Task<IActionResult> BuscaGeneroPorId(int id)
        {
            var genero = await _generoService.BuscaGeneroPorId(id);
            return Ok(genero);
        }

        [HttpPost("SalvarGenero")]
        public async Task<IActionResult> SalvarGenero(DTO.GeneroDTO model)
        {
            var generoViewModel = new ViewModel.Genero
            {
                Nome = model.Nome,
                Id = model.Id,
            };
            await _generoService.Incluir(generoViewModel);
            return Ok();
        }

        [HttpDelete("ExcluirGenero/{id}")]
        public async Task<IActionResult> ExcluirGenero(int id)
        {
            await _generoService.Excluir(id);
            return Ok();
        }
    }
}
