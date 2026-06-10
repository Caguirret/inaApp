using inaApp.Common.interfaces;
using inaApp.Common.Exceptions;
using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Services

    //Tarea Hacer lo mismo pero con cliente: Implementar lo mismo que producto pero con cliente
{
    public class ProductoServices : IGenericService<Producto>
    {
        private readonly IGenericRepository<Producto> _productoRepo;

        public ProductoServices(IGenericRepository<Producto> productoRepo)
        {
            _productoRepo = productoRepo;
        }

        public async Task<Producto> ActualizarAsync(Producto entity)
        {
            if (entity.precio <= 0)
            {
                throw new InvalidPriceException("El precio digitado debe ser mayor a 0");
            }

            //Validar que no se duplique el nombre
            var producto = await _productoRepo.ObtenerTodoAsync();

            if(producto.Any(p => p.nombre.ToLower() == entity.nombre.ToLower() && p.id != entity.id && p.estado==true))
            {
                throw new DuplicateProductNameException($"El nombre{entity.nombre} Ya existe");
            }
            return await _productoRepo.ActualizarAsync(entity);
        }

        public async Task<Producto> CrearAsync(Producto entity)
        {
            //Reglas de negocio
            //precio > 0 == InvalidPriceException
            //nombre repetido == DuplicateProductNameException
            //stock negativo a 0 == InvalidStockException

            if (entity.precio <= 0)
            {
                throw new InvalidPriceException("El precio digitado debe ser mayor a 0");
            }

            //Validar que no se duplique el nombre
            var producto = await _productoRepo.ObtenerTodoAsync();

            bool nombrExist = producto.Any(p =>
            p.nombre.ToLower() == entity.nombre.ToLower());

            if (nombrExist)
            {
                throw new DuplicateProductNameException(
                    $"Lo siento, pero ya existe un producto con el nombre: {entity.nombre}");
            }

            return await _productoRepo.CrearAsync(entity);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _productoRepo.EliminarAsync(id);
        }

        public async Task<List<Producto>> obtenerTodoAsync()
        {
            return await _productoRepo.ObtenerTodoAsync();
        }

        async Task<Producto> IGenericService<Producto>.obtenerIdAsync(int id)
        {
            var producto= await _productoRepo.ObtenerPorIdAsync(id);
            if (producto is null)
            {
                throw new NotFoundException($"El producto con id {id} no existe");
            }

            return producto;
        }
    }
}
