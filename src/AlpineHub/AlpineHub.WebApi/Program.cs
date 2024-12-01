using AlpineHub.Web.Infrastructure.Extensions;
namespace AlpineHub.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string? appOrigin = builder.Configuration.GetValue<string>("ClientOrigins:AlpineHub");

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddCors(cfg =>
                {
                    if (!String.IsNullOrWhiteSpace(appOrigin))
                    {
                        cfg.AddPolicy("AllowMyServer", policyBld =>
                        {
                            policyBld
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials()
                                .WithOrigins(appOrigin);
                        });
                    }
                    else
                    {
                        throw new ArgumentException("ClientOrigins:AlpineHub is not set in appsettings.json");
                    }
                });
            }
            builder.Services.AddAppDbContext(builder.Configuration);
            builder.Services.AddApplicationServices();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            if (app.Environment.IsDevelopment())
            {
                app.UseCors("AllowMyServer");
            }
            app.MapControllers();

            app.Run();
        }
    }

}
