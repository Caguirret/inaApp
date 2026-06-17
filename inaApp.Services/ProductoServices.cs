using inaApp.Common.interfaces;
using inaApp.Common.Exceptions;
using inaApp.Entitites;
using inaApp.Common.Response;
using System;
using System.Collections.Generic;
using System.Text;
using inaApp.DTOs.Producto;
using AutoMapper;

namespace inaApp.Services

    //Tarea Hacer lo mismo pero con cliente: Implementar lo mismo que producto pero con cliente
{
    public class ProductoServices : IGenericService<
        ProductoResponseDTO,
        ProductoCreateDTO,
        ProductoUpdateDTO>
    {
        private readonly IGenericRepository<Producto> _productoRepo;
        private readonly IMapper _mapper;

        public ProductoServices(IGenericRepository<Producto> productoRepo, IMapper mapper)
        {
            _productoRepo = productoRepo;
            _mapper = mapper;
        }

        public async Task<Response<ProductoResponseDTO>> ActualizarAsync(ProductoUpdateDTO entity)
        {
            if (entity.Precio <= 0)
            {
                throw new InvalidPriceException("El precio digitado debe ser mayor a 0");
            }

            var productos = await _productoRepo.ObtenerTodoAsync();

            if (productos.Any(p =>
                p.Nombre.ToLower() == entity.Nombre.ToLower() &&
                p.Id != entity.Id &&
                p.Estado))
            {
                throw new DuplicateProductNameException(
                    $"El nombre {entity.Nombre} ya existe");
            }

            var productoActualizar = _mapper.Map<Producto>(entity);

            productoActualizar =
                await _productoRepo.ActualizarAsync(productoActualizar);

            return new Response<ProductoResponseDTO>
            {
                Data = _mapper.Map<ProductoResponseDTO>(productoActualizar),
                Message = "Producto actualizado exitosamente",
                Success = true
            };
        }

        public async Task<Response<ProductoResponseDTO>> CrearAsync(ProductoCreateDTO entity)
        {
            if (entity.Precio <= 0)
            {
                throw new InvalidPriceException("El precio digitado debe ser mayor a 0");
            }

            var productos = await _productoRepo.ObtenerTodoAsync();

            bool nombrExist = productos.Any(p =>
                p.Nombre.ToLower() == entity.Nombre.ToLower());

            if (nombrExist)
            {
                throw new DuplicateProductNameException(
                    $"Lo siento, pero ya existe un producto con el nombre: {entity.Nombre}");
            }

            Producto nuevoProducto = _mapper.Map<Producto>(entity);

            nuevoProducto.Estado = true;

            Producto productoCreado =
                await _productoRepo.CrearAsync(nuevoProducto);

            return new Response<ProductoResponseDTO>
            {
                Data = _mapper.Map<ProductoResponseDTO>(productoCreado),
                Message = "Producto creado exitosamente",
                Success = true
            };
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            var eliminado = await _productoRepo.EliminarAsync(id);

            return new Response<bool>
            {
                Data = eliminado,
                Message = eliminado
                ? "Producto eliminado con exito" 
                : "No se pudo eliminar el producto",
                Success = eliminado
            };
        }

        public async Task<Response<List<ProductoResponseDTO>>> ObtenerTodoAsync()
        {
            //obtener la lista de los producto por medio de los dtos
            var lista = await _productoRepo.ObtenerTodoAsync();

            var productos = _mapper.Map<List<ProductoResponseDTO>>(lista);

            return new Response<List<ProductoResponseDTO>>
            {
                Data = productos,
                Message = "Lista obtenida del sistema existosamente",
                Success = true
            };

        }

        public async Task<Response<ProductoResponseDTO>> ObtenerIdAsync(int id)
        {
            var producto= await _productoRepo.ObtenerPorIdAsync(id);

            if (producto is null)
            {
                throw new NotFoundException($"El producto con id {id} no existe");
            }

            return new Response<ProductoResponseDTO>
            {
                Data = _mapper.Map<ProductoResponseDTO>(producto),
                Message = "Producto encontrado dentro del sistema",
                Success = true
            };
        }
    }
}
