using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.@interfaces
{
    public interface ICLienteService
    {
        List< Cliente > obtenerTodoAsync();

        Cliente obtenerIdAsync(int id);

        Cliente CrearAsync(Cliente cliente);

        Cliente ActualizarAsync(Cliente cliente);

        Task<bool> EliminarAsync(int id);
    }
}
