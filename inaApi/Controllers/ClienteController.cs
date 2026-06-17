using inaApp.Common.Exceptions;
using inaApp.Common.interfaces;
using inaApp.DTOs.Cliente;
using inaApp.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace inaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IGenericService<ClienteResponseDTO, ClienteCreateDTO, ClienteUpdateDTO> _clienteService;

        public ClienteController(IGenericService<ClienteResponseDTO, ClienteCreateDTO, ClienteUpdateDTO> clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/cliente
        [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            var clientes = await _clienteService.ObtenerTodoAsync();
            return Ok(clientes);
        }

        // GET: api/cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerPorId(int id)
        {
            try
            {
                var cliente = await _clienteService.ObtenerIdAsync(id);
                return Ok(cliente);
            }
            catch (NotFoundException ex)
            {

                return NotFound("El cliente seleccionado no existe");
            }
        }

        // POST: api/cliente
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ClienteCreateDTO cliente)
        {
            try
            {
                var result = await _clienteService.CrearAsync(cliente);
                return Created("Cliente creado", result);
            }
            catch (DuplicateClientException ex)
            {
                return BadRequest("Ya existe ese cliente registrado");
            }
            catch (InvalidEmailExceptions ex)
            {
                return BadRequest("Ese correo no es valido");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor, contacte al sysAdmin");
            }
        }

        // PUT: api/cliente
        [HttpPut]
        public async Task<IActionResult> Actualizar(ClienteUpdateDTO cliente)
        {
            try
            {
                var result = await _clienteService.ActualizarAsync(cliente);
                return Ok(result);
            }
            catch (DuplicateClientException ex)
            {
                return BadRequest("Error al modificar datos invalidos");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // DELETE: api/cliente/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _clienteService.EliminarAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}