using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.interfaces
{
    //Parametrizar la interfaz para que pueda ser reutilizada con cualquier entidad
    public interface IGenericService<E>
    {
        Task<List<E>> obtenerTodoAsync();

        Task<E> obtenerIdAsync(int id);

        Task<E> CrearAsync(E entity);

        Task<E> ActualizarAsync(E entity);

        Task<bool> EliminarAsync(int id);
    }
}
