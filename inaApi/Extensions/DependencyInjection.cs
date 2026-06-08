using inaApp.Common.interfaces;
using inaApp.Data.cs;
using inaApp.Entitites;
using inaApp.Repository;
using inaApp.Services;
using Microsoft.EntityFrameworkCore;

namespace inaApi.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services,
            IConfiguration configuration)
        {
            //Base de datos 

            services.AddDbContext<ApplicationDbContex>(options=>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));

            });



            //Inyecciones de dependencia de services 
            services.AddScoped<IGenericService<Producto>, ProductoServices>();
            services.AddScoped<IGenericService<Cliente>, ClienteService>();




            //Inyecciones de dependencias de repositorios 
            services.AddScoped<IGenericRepository<Producto>, ProductoRepository>();
            services.AddScoped<IGenericRepository<Cliente>, ClienteRepository>();

            return services;
        }





    }
}
