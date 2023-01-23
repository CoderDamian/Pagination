using Microsoft.EntityFrameworkCore;
using Persistence;

namespace RESTful.Extensions
{
    public static class ServicesExtension
    {
        public static void AddSqlInMemory(this IServiceCollection services )
        {
            services.AddDbContext<HobbyDbContext>(opt => opt.UseInMemoryDatabase("HobbyDb"));
        }
    }
}