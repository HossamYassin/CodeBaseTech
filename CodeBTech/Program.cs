using Application.Services;
using Domain.Configuration;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Mapping;
using Infrastructure;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodeBTech
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
             options.UseSqlServer(
                 builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(UserMappingProfile));

            //Email settings options
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

            // Add services
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<ISMSService, SMSService>();
            builder.Services.AddScoped<IRandomDigitService, RandomDigitService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();


            app.Run();
        }
    }
}
