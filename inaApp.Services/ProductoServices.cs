using inaApp.Common.@interface;
using inaApp.Common.Interfaces;
using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Services

    //Tarea Hacer lo mismo pero con cliente: Implementar lo mismo que producto pero con cliente
{
    public class ProductoServices : IProductoService
    {
        private readonly IProductoRepository productoRepository;

        public Task<Producto> ActualizarAsync(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Producto CrearAsync(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> obtenerIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> obtenerTodoAsync()
        {
            productoRepository.obtenerTodoAsync();
            throw new NotImplementedException();
        }

        List<Producto> IProductoService.obtenerTodoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
