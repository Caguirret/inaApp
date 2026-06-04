using inaApp.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace inaApp.Common.@interface
{
    public interface IProductoService
    {

        List<Producto> obtenerTodoAsync();

        List<Producto> obtenerIdAsync(int id);

        Producto CrearAsync(Producto producto);

        Task<Producto> ActualizarAsync(Producto producto);

        Task<bool> EliminarAsync(int id);






    }
}
