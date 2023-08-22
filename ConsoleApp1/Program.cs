using AutoMapper;
using ConsoleApp1;
using ConsoleApp1.Mapping;
using ConsoleApp1.Settings;
using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Implementations;
using Services.Interfaces;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        await host.RunAsync();
    }


    static IHostBuilder CreateHostBuilder(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder();
        hostBuilder.ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: true);
            })
            .ConfigureServices((hostContext, services) =>
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<UserMappingsProfile>();
                    cfg.AddProfile<Services.Mapping.UserMappingsProfile>();
                });
                configuration.AssertConfigurationIsValid();
                services.AddSingleton<IMapper>(new Mapper(configuration));

                var databaseConfig = hostContext.Configuration.GetSection("DBConfig").Get<ApplicationSettings>();
                
                // services.AddDbContext<DBContext>(o => o.UseNpgsql(databaseConfig.ConnectionString));
                services.AddDbContext<DBContext>(o => { o.UseNpgsql(databaseConfig.ConnectionString); }, ServiceLifetime.Transient, ServiceLifetime.Transient);

                services.AddTransient<IUserRepository, SQLRepository>();
                services.AddTransient<IRepository<Product>, SQLRepository>();
                services.AddTransient<IRepository<Advertisement>, SQLRepository>();
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<IProductService, ProductService>();
                services.AddTransient<IAdvertisementService, AdvertisementService>();

                services.AddHostedService<ConsoleApplicationHostedService>();
            });


        return hostBuilder;
    }

}
