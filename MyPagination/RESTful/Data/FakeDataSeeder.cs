using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Entities;

namespace RESTful.Data
{
    public class FakeDataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var myContext = new HobbyDbContext(serviceProvider.GetRequiredService<DbContextOptions<HobbyDbContext>>());

            if (myContext.Hobbies.Any())
                return;

            var hobbies = new List<Hobby>
            {
                new Hobby{ Name = "Cooking", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Listening to Music", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Drinking Beer", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Playing Guitar", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Blogging", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Vlogging", CreatedAt = DateTime.Now },
                new Hobby{ Name = "Travelling", CreatedAt = DateTime.Now },
            };

            myContext.Hobbies.AddRange(hobbies);

            myContext.SaveChangesAsync();
        }
    }
}
