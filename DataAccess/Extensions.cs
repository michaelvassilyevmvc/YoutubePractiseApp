using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class Extensions
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddDbContext<AppContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Port=5432;Database=MascaradeDB;Username=postgres;Password='Q2w3e4r5!'");
            });
            return services;
        }
    }
}
