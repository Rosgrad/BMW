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
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Profile>, ProfileRepository>();

        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarsService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }
}
