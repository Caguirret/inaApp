using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace inaApp.Common.Interfaces
{
    public interface IProductoRepository
    {
        List<Producto> obtenerTodoAsync();

        List<Producto> obtenerIdAsync(int id);

        Producto CrearAsync(Producto producto);

        Task<Producto> ActualizarAsync(Producto producto);

        Task<bool> EliminarAsync(int id);


    }
}
