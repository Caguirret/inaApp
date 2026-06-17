using inaApp.Common.interfaces;
using inaApp.Data;
using inaApp.DTOs.Cliente;
using inaApp.DTOs.Producto;
using inaApp.Entitites;
using inaApp.Repository;
using inaApp.Services;
using inaApp.Services.Mapping;
using Microsoft.EntityFrameworkCore;

namespace inaApi.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicationService
            (this IServiceCollection services,
            IConfiguration configuration)
        {
            //Base de datos - dbContext

            services.AddDbContext<ApplicationDbContex>(options=>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));

            });

            //Profile auto mapper
            services.AddAutoMapper(fg => { }, typeof(MappingProfile));



            //Inyecciones de dependencia de services 
            services.AddScoped<IGenericService<ProductoResponseDTO, ProductoCreateDTO, ProductoUpdateDTO>, ProductoServices>();
            services.AddScoped<IGenericService<ClienteResponseDTO, ClienteCreateDTO, ClienteUpdateDTO>, ClienteService>();




            //Inyecciones de dependencias de repositorios 
            services.AddScoped<IGenericRepository<Producto>, ProductoRepository>();
            services.AddScoped<IGenericRepository<Cliente>, ClienteRepository>();

            return services;
        }





    }
}
