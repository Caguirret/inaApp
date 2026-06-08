using inaApp.Common.interfaces;
using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Repository
{
    public class ProductoRepository : IGenericRepository<Producto>
    {
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

        public Task<List<Producto>> ObtenerTodoAsync()
        {
            throw new NotImplementedException();
        }

        Task<Producto> IGenericRepository<Producto>.ObtenerIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
