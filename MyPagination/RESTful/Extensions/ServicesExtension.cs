using Microsoft.EntityFrameworkCore;
using Persistence;
using RESTful.Contracts;
using RESTful.Service;

namespace RESTful.Extensions
{
    public static class ServicesExtension
    {
        public static void AddSqlInMemory(this IServiceCollection services )
        {
            services.AddDbContext<HobbyDbContext>(opt => opt.UseInMemoryDatabase("HobbyDb"));
        }

        public static void AddHobbyService(this IServiceCollection services)
            => services.AddTransient<IHobbyService, HobbyService>();
    }
}