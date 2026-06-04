using System;
using System.Collections.Generic;
using System.Text;
using inaApp.Entitites;

namespace inaApp.Common.interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ObtenerTodo();

        List<Cliente> obtenerTodoAsync();

        List<Cliente> obtenerIdAsync(int id);

        Cliente CrearAsync(Cliente cliente);

        Task<Cliente> ActualizarAsync(Cliente cliente);

        Task<bool> EliminarAsync(int id);
    }
}
