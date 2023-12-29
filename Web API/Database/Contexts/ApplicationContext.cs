using Microsoft.EntityFrameworkCore;
using Web_API.Domain.Entities.Joke;

namespace Web_API.Database.Contexts
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Joke> Jokes { get; set; }
        public ApplicationContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Jokes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
