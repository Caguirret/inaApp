using inaApp.Common.interfaces;
using inaApp.Entitites;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Index()
        {
            var data = await _productoService.obtenerTodoAsync();
            return Ok(data);
        }

        // GET: api/producto/5
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            return Ok(id);
        }

        // POST: api/producto
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            var result = await _productoService.CrearAsync(producto);
            return Ok(result);
        }

        // PUT: api/producto
        [HttpPut]
        public async Task<IActionResult> Edit(Producto producto)
        {
            var result = await _productoService.ActualizarAsync(producto);
            return Ok(result);
        }

        // DELETE: api/producto/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productoService.EliminarAsync(id);
            return Ok(result);
        }
    }
}