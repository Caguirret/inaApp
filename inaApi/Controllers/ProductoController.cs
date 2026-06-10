using inaApp.Common.interfaces;
using inaApp.Entitites;

using Microsoft.AspNetCore.Mvc;

namespace inaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IGenericService<Producto> _productoService;

        public ProductoController(IGenericService<Producto> productoServ)
        {
            _productoService = productoServ;
        }

        // GET: api/producto
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _productoService.obtenerTodoAsync();
            return Ok(data);
        }

        // GET: api/producto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var producto = await _productoService.obtenerIdAsync(id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Producto producto)
        {
            try
            {
                var result = await _productoService.CrearAsync(producto);
                return Created("Producto Creado.", result);
            }
            catch (Exception)
            {

                return BadRequest("Error al crear el producto.");
            }
        }

        // PUT: api/producto
        [HttpPut]
        public async Task<IActionResult> ActualizarAsync([FromBody] Producto producto)
        {
            var result = await _productoService.ActualizarAsync(producto);
            return Ok(result);
        }

        // DELETE: api/producto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Error al eliminar, Id incorrecto");

                var result = await _productoService.EliminarAsync(id);

                return result ? Ok("Producto eliminado") : BadRequest("Error al eliminar alk producto");

            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Error de servidor contacte al admin");
            }
        }
    }
}