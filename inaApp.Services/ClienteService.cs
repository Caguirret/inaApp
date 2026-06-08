using inaApp.Common.interfaces;
using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Services
{
    public class ClienteService : IGenericService<Cliente>
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public ClienteService(IGenericRepository<Cliente> clienteRepo)
        {
            _clienteRepository = clienteRepo;
        }

        public Task<Cliente> ActualizarAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> CrearAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> obtenerTodoAsync()
        {
            throw new NotImplementedException();
        }

        Task<Cliente> IGenericService<Cliente>.obtenerIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
