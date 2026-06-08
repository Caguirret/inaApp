using inaApp.Common.interfaces;
using inaApp.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace inaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IGenericService<Cliente> _clienteService;

        public ClienteController(IGenericService<Cliente> clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/cliente
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _clienteService.obtenerTodoAsync();
            return Ok(data);
        }

        // GET: api/cliente/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _clienteService.obtenerIdAsync(id);
            return Ok(data);
        }

        // POST: api/cliente
        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            var result = await _clienteService.CrearAsync(cliente);
            return Ok(result);
        }

        // PUT: api/cliente
        [HttpPut]
        public async Task<IActionResult> Edit(Cliente cliente)
        {
            var result = await _clienteService.ActualizarAsync(cliente);
            return Ok(result);
        }

        // DELETE: api/cliente/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clienteService.EliminarAsync(id);
            return Ok(result);
        }
    }
}