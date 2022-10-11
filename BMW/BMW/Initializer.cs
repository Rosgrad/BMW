using BMW.Dal.Interfaces;
using BMW.Dal.Repositories;
using BMW.Domain.Entity;
using BMW.Servise.Implementatios;
using BMW.Servise.Interfaces;

namespace BMW
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Cars>, BMWRepository>();
           
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarsService>();

        }
    }
}
