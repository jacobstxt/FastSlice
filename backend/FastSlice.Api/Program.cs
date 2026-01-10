using Core.Extensions;
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

            builder.Services.AddIdentityConfiguration();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();


            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddCors();

            var app = builder.Build();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    // Стандартний шлях для Swashbuckle
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "FastSlice API v1");
                });
            }
        
            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();
            app.UseStaticFiles();


            await app.SeedData();

            app.Run();
        }
    }
}
