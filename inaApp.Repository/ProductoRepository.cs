using inaApp.Common.Interfaces;
using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        public ProductoRepository() { }

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

        public List<Producto> obtenerTodoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
