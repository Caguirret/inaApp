using inaApp.Common.Response;

namespace inaApp.Common.interfaces
{
    //Parametrizar la interfaz para que pueda ser reutilizada con cualquier entidad
    public interface IGenericService<TResponse, TCreate, TUpdate>
    {
        Task<Response<List<TResponse>>> ObtenerTodoAsync();

        Task<Response<TResponse>> ObtenerIdAsync(int Id);

        Task<Response<TResponse>> CrearAsync(TCreate entity);

        Task<Response<TResponse>> ActualizarAsync(TUpdate entity);

        Task<Response<bool>> EliminarAsync(int Id);
    }
}
