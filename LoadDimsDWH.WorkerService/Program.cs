using LoadDimsDWH.Data.Context;
using LoadDimsDWH.Data.Interfaces;
using LoadDimsDWH.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace LoadDimsDWH.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);

            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddEnvironmentVariables();
                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            });

            builder.ConfigureServices((hostContext, services) =>
            {
                var configuration = hostContext.Configuration;

                // Configuración de DbContext específico para DbOrders
                services.AddDbContext<DbOrdersContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DbOrdersConnection"),
                        sqlOptions => sqlOptions.EnableRetryOnFailure()));

                // Configuración de DbContext específico para Northwind
                services.AddDbContext<NorthwindContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("NortwindConnection"),
                        sqlOptions => sqlOptions.EnableRetryOnFailure()));

                // Servicios y worker
                services.AddScoped<IDataServiceDwOrders, DataServiceDwOrders>();
                services.AddHostedService<Worker>();
            });

            builder.Build().Run();
        }
    }
}
