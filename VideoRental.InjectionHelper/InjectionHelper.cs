using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VideoRental.DataAccess;
using VideoRental.DataAccess.EFImplementations;
using VideoRental.Domain.Models;
using VideoRental.Services.Implementations;
using VideoRental.Services.Interfaces;

namespace VideoRental.InjectionHelper
{
    public static class InjectionHelper
    {
        public static void InjectionRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Movie>, MovieRepository>();
            services.AddTransient<IRepository<Cast>, CastRepository>();
            services.AddTransient<IRepository<Rental>, RentalRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IRentalService, RentalService>();
            services.AddTransient<ICastService, CastService>();
        }

        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<VideoRentalDbContext>(options =>
            {
                //local server (our machine), the database is PizzaAppG6, we use Windows credentials
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=VideoRental;Trusted_Connection=True;TrustServerCertificate=True");
            });
        }
    }
}
