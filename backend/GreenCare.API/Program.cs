using GreenCare.API.Data;
using GreenCare.API.Repositories.Interfaces;
using GreenCare.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using GreenCare.API.Repositories.Implementations;
using GreenCare.API.Services.Implementations;
using GreenCare.API.Repositories;
using GreenCare.API.Services;

namespace GreenCare.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<GreenCareDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IPlantTypeRepository, PlantTypeRepository>();
            builder.Services.AddScoped<IPlantTypeService, PlantTypeService>();


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

            app.Run();
        }
    }
}
