using inaApp.Common.interfaces;
using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Services

    //Tarea Hacer lo mismo pero con cliente: Implementar lo mismo que producto pero con cliente
{
    public class ProductoServices : IGenericService<Producto>
    {
        private readonly IGenericRepository<Producto> _repository;

        public ProductoServices(IGenericRepository<Producto> _productoRepo)
        {
            _productoRepo = _repository;
        }

        public Task<Producto> ActualizarAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> CrearAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> obtenerTodoAsync()
        {
            return await _repository.ObtenerTodoAsync();
        }

        Task<Producto> IGenericService<Producto>.obtenerIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
