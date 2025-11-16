using Core.Interfaces;
using Core.Services;
using Domain;
using Microsoft.EntityFrameworkCore;



namespace FastSlice.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(opt =>
              opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IImageService, ImageService>();


            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

            await app.SeedData();

            app.Run();
        }
    }
}
