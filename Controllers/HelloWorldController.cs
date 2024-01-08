using CursoApiRest.Models;
using CursoApiRest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        readonly IHelloWorldService _helloWorldService;
        readonly TareasContext _tareasContext;
        public HelloWorldController(IHelloWorldService helloWorldService, TareasContext tareasContext)
        {
            _helloWorldService = helloWorldService;
            _tareasContext = tareasContext;
        }

        [HttpGet]
        public IActionResult GetHelloWorld()
        {
            return Ok(_helloWorldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("CreateDatabase")]
        public IActionResult CreateDatabase()
        {
            _tareasContext.Database.EnsureCreated();
            return Ok();
        }
    }
}
