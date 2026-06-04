using inaApp.Common.interfaces;
using inaApp.Common.@interface;
using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Services
{
    public class ClienteService : ICLienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            
        }

        public Cliente ActualizarAsync(Cliente cliente)
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

        public Cliente obtenerIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> obtenerTodoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
