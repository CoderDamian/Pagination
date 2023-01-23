using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence
{
    public class HobbyDbContext : DbContext
    {
        public HobbyDbContext(DbContextOptions<HobbyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hobby> Hobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Unlike in EF6, in EF Core, seeding data can be associated with an entity type as part of the model configuration
            builder.Entity<Hobby>().HasData(
                new Hobby { Name = "Cooking", CreatedAt = DateTime.Now },
                new Hobby { Name = "Listening to Music", CreatedAt = DateTime.Now },
                new Hobby { Name = "Drinking Beer", CreatedAt = DateTime.Now },
                new Hobby { Name = "Playing Guitar", CreatedAt = DateTime.Now },
                new Hobby { Name = "Blogging", CreatedAt = DateTime.Now },
                new Hobby { Name = "Vlogging", CreatedAt = DateTime.Now },
                new Hobby { Name = "Travelling", CreatedAt = DateTime.Now }
                );
        }
    }
}
