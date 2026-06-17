using inaApp.Common.Exceptions;
using inaApp.Common.interfaces;
using inaApp.DTOs.Producto;
using inaApp.Entitites;

using Microsoft.AspNetCore.Mvc;

namespace inaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IGenericService<ProductoResponseDTO, ProductoCreateDTO, ProductoUpdateDTO> _productoService;

        public ProductoController(IGenericService<ProductoResponseDTO, ProductoCreateDTO, ProductoUpdateDTO> productoServ)
        {
            _productoService = productoServ;
        }

        // GET: api/producto
        [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            try
            {
                var productos = await _productoService.ObtenerTodoAsync();
                return Ok(productos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error servidor contacte al administrador");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductoCreateDTO productoDTO)
        {
            try
            {

                if(!ModelState.IsValid)
                return BadRequest(ModelState);

                var result = await _productoService.CrearAsync(productoDTO);
                return Created("Producto Creado.", result);
            }
            catch (InvalidPriceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(DuplicateProductNameException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidStockException ex)
            {
                return BadRequest(ex);
            }

            catch(Exception ex)
            {

                return StatusCode(500, "Error al crear el producto.");
            }
        }

        // delete:api/producto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Error al eliminar, Id incorrecto");

                var result = await _productoService.EliminarAsync(id);

                return result.Success
                    ? Ok(result)
                    : BadRequest(result);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Error de servidor contacte al admin");
            }
        }

        // GET: api/producto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id inválido");

                var producto = await _productoService.ObtenerIdAsync(id);

                if (producto == null)
                    return NotFound("Producto no encontrado");

                return Ok(producto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }

        //put:api/producto
        [HttpPut]
        public async Task<ActionResult> ActualizarAsync([FromBody] ProductoUpdateDTO productoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var result = await _productoService.ActualizarAsync(productoDTO);

                return Ok(result);
            }
            catch (InvalidPriceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidStockException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicateProductNameException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error de servidor, contacte al SysAdmin");
            }
        }


    }
}