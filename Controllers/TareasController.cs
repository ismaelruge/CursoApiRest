using CursoApiRest.Models;
using CursoApiRest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        readonly ITareasService _tareasService;

        public TareasController(ITareasService tareasService)
        {
            _tareasService = tareasService;
        }

        [HttpGet]
        public IActionResult ObtenerTareas()
        {
            return Ok(_tareasService.ObtenerTareas());
        }

        [HttpGet("{tareaId}")]
        public IActionResult ObtenerTareaPorId([FromRoute] Guid tareaId)
        {
            var tarea = _tareasService.ObtenerTareaPorId(tareaId);
            if (tarea == null)
            {
                return NotFound();
            }
            return Ok(tarea);
        }

        [HttpPost]
        public IActionResult CrearTarea([FromBody] Tarea tarea)
        {
            var tareaCreada = _tareasService.CrearTarea(tarea);
            return CreatedAtAction(nameof(ObtenerTareaPorId), new { tareaId = tareaCreada.TareaId }, tareaCreada);
        }

        [HttpPut]
        public IActionResult ActualizarTarea([FromBody] Tarea tarea)
        {
            var tareaActualizada = _tareasService.ActualizarTarea(tarea);
            if (tareaActualizada == null)
            {
                return NotFound();
            }
            return Ok(tareaActualizada);
        }

        [HttpDelete("{tareaId}")]
        public IActionResult EliminarTarea([FromRoute] Guid tareaId)
        {
            var tareaEliminada = _tareasService.EliminarTarea(tareaId);
            if (!tareaEliminada)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
