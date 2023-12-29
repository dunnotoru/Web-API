using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_API.Domain.Entities.Joke;

namespace Web_API.Database.Configurations
{
    public class JokeConfiguration : IEntityTypeConfiguration<Joke>
    {
        public void Configure(EntityTypeBuilder<Joke> builder)
        {
            builder.HasKey(o => o.Id);
        }
    }
}
