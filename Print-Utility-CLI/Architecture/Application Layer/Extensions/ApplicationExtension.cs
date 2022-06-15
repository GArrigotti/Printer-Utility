using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Print_Utility_Core.Architecture.Data_Layer.Contexts;
using Print_Utility_Core.Architecture.Data_Layer.Factories;
using Print_Utility_Core.Architecture.Data_Layer.Repositories;
using Print_Utility_Core.Architecture.Data_Layer.Utilities;
using Print_Utility_Core.Architecture.Service_Layer;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_CLI.Architecture.Application_Layer.Extensions
{
    internal static class ApplicationExtension
    {
        private static readonly string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\Clean Water Services\Print Utility\Core\Logs";

        public static void Build(this ConfigurationManager manager, string configuration) => manager
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(configuration, false, true)
            .AddUserSecrets<Program>(false, true)
            .AddEnvironmentVariables()
            .Build();

        public static void RegisterLogger(this IHostBuilder host)
        {
            host.UseSerilog((context, configuration) => configuration
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(path));

            BuildStaticSerilog();
        }

        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddLogging(logger => logger.AddSerilog());

            /* Core: 
             * Data Layer: */
            services.AddSingleton<IDbContext, DbContext>();
            services.AddSingleton<IDbFactory, DbFactory>();
            services.AddSingleton<IDeviceRepository, DeviceRepository>();
            
            services.AddSingleton<IEmbeddedResourceUtility, EmbeddedResourceUtility>();

            /* Core: 
             * Service Layer: */

            services.AddSingleton<IActiveDirectoryService, ActiveDirectoryService>();
        }

        #region Private:

        private static void BuildStaticSerilog() => Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("")
            .CreateLogger();

        #endregion
    }
}
