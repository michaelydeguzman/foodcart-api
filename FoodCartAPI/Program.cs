using FoodCart.Application;
using FoodCart.Application.Interfaces;
using FoodCart.Domain.Repositories;
using FoodCart.Infrastructure.Data;
using FoodCart.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodCart.API
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

            builder.Services.AddDbContext<FoodCartContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("FoodCartDbConnection")));

            // Services
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICartService, CartService>();

            // Repositories
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Enable CORS only in Development environment
            if (app.Environment.IsDevelopment())
            {
                app.UseCors("AllowReactApp");
            }

            app.MapControllers();

            app.Run();
        }
    }
}