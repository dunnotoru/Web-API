using System.Diagnostics;
using Web_API.Database.Contexts;
using Web_API.Database.Repositories;
using Web_API.Domain.Repositories;

namespace Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationContext>();
            builder.Services.AddControllers();

            builder.Services.Add(ServiceDescriptor.Describe(typeof(IJokeRepository), typeof(JokeRepository), ServiceLifetime.Transient));

            ServiceCollection collection = new ServiceCollection();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            ApplicationContext a = new ApplicationContext();

            app.Run();
        }
    }
}