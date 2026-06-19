using inaApp.Common.Exceptions;
using inaApp.Common.interfaces;
using inaApp.DTOs.Categoria;
using Microsoft.AspNetCore.Mvc;

namespace inaApp.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {

        private readonly IGenericService<CategoriaResponseDTO,
            CategoriaCreateDTO,
            CategoriaUpdateDTO> _categoriaService;

        public CategoriaController(
            IGenericService<
                CategoriaResponseDTO,
                CategoriaCreateDTO,
                CategoriaUpdateDTO> categoriaService)
        {
            _categoriaService = categoriaService;
        }

        //GET API/CATEGORIA
        [HttpGet]
        public async Task<ActionResult> ObtenerTodoAsync()
        {
            try
            {
                var categorias = await _categoriaService.ObtenerTodoAsync();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }

        }

        //GET API/CATEGORIA
        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerIdAsync(int id) 
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id invalido");

                var categoria = await _categoriaService.ObtenerIdAsync(id);

                return Ok(categoria);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }


        //POST API/CATEGORIA
        [HttpPost]
        public async Task<ActionResult> CrearAsync([FromBody] CategoriaCreateDTO categoriaDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _categoriaService.CrearAsync(categoriaDTO);

                return Created("Categoria Creada Correctamente", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //PUT API/CATEGORIA
        [HttpPut]
        public async Task<ActionResult> ActualizarAsync([FromBody] CategoriaUpdateDTO categoriaUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _categoriaService.ActualizarAsync(categoriaUpdateDTO);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> EliminarAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id invalido");

                var result = await _categoriaService.EliminarAsync(id);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}


