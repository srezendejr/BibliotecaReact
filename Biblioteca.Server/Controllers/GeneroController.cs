using Biblioteca.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Server.Controllers
{
    [Route("api/[controller]")]
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
    }
}
