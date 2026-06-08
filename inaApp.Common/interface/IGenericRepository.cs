using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.interfaces
{
    public interface IGenericRepository<E>
    {
        Task<List<E>> ObtenerTodoAsync();

        Task<E> ObtenerIdAsync(int id);

        Task<E> CrearAsync(E entity);

        Task<E> ActualizarAsync(E entity);

        Task<bool> EliminarAsync(int id);
    }
}
