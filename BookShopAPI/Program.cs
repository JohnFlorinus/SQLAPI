
using BookShopAPI.Context;
using BookShopAPI.Interfaces;
using BookShopAPI.Repositories;

namespace BookShopAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var allCORS = "everything";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: allCORS,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                                  });
            });

            builder.Services.AddSingleton<UserRepository>();
            builder.Services.AddSingleton<DBContext>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
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

            app.UseCors(allCORS);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
