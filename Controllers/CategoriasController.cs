using CursoApiRest.Models;
using CursoApiRest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        readonly ICategoriaService _categoriaService;
        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult ObtenerCategorias()
        {
            return Ok(_categoriaService.ObtenerCategorias());
        }

        [HttpGet("{categoriaId}")]
        public IActionResult ObtenerCategoriaPorId([FromRoute] Guid categoriaId)
        {
            var categoria = _categoriaService.ObtenerCategoriaPorId(categoriaId);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult CrearCategoria([FromBody] Categoria categoria)
        {
            var categoriaCreada = _categoriaService.CrearCategoria(categoria);
            return CreatedAtAction(nameof(ObtenerCategoriaPorId), new { categoriaId = categoriaCreada.CategoriaId }, categoriaCreada);
        }

        [HttpPut]
        public IActionResult ActualizarCategoria([FromBody] Categoria categoria)
        {
            var categoriaActualizada = _categoriaService.ActualizarCategoria(categoria);
            if (categoriaActualizada == null)
            {
                return NotFound();
            }
            return Ok(categoriaActualizada);
        }

        [HttpDelete]
        [Route("{categoriaId}")]
        public IActionResult EliminarCategoria(Guid categoriaId)
        {
            var categoriaEliminada = _categoriaService.EliminarCategoria(categoriaId);
            if (!categoriaEliminada)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
