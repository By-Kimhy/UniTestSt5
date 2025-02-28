using Microsoft.EntityFrameworkCore;
using UniTestSt5.Data;
using UniTestSt5.Services;

namespace UniTestSt5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var conString = @"Server=.\SQLEXPRESS;Database=St5TestApi;User Id=sa;Password=12345;TrustServerCertificate=true;";
            builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(conString));

            // Add services to the container.
            builder.Services.AddTransient<ICategoryService, CatogoryService>();
            builder.Services.AddControllers();
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

            app.Run();
        }
    }
}
