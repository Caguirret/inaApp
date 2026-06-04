using inaApp.Common.interfaces;
using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public Task<Cliente> ActualizarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente CrearAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> obtenerIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObtenerTodo()
        {
            throw new NotImplementedException();
        }

        public List<Cliente> obtenerTodoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
