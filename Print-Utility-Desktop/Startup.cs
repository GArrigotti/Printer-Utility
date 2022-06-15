using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Print_Utility_Core.Architecture.Data_Layer.Repositories;
using Print_Utility_Core.Architecture.Domain_Layer.Entities;
using Print_Utility_Core.Architecture.Service_Layer.Utilities;
using Print_Utility_Desktop.Architecture.Application_Layer.Extensions;
using Serilog;

namespace Print_Utility_Desktop
{
    internal class Startup
    {
        private static readonly IServiceProvider provider;
        private static readonly string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\Clean Water Services\Print Utility\Core\Logs";

        #region Constructor:

        static Startup() => provider = Configure();

        #endregion

        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();

            #pragma warning disable CS8604

            /* Important:
             * If either of the below are null, I would expect the application
             * to completely crash. */

            Application.Run(new frmPrintUtility(
                repository: provider.GetService<IDeviceRepository>(),
                utility: provider.GetService<IPrintManagerUtility>(),
                configuration: provider.GetService<IOptions<ConfigurationModel>>(),
                logger: provider.GetService<ILogger>())
            );

            #pragma warning restore CS8604

        }

        #region Protected:

        protected static IServiceProvider Configure()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("desktop-application-settings.json", false, true)
                .AddUserSecrets<Startup>(false, true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File($@"{path}\desktop log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            return new ServiceCollection()
                .AddLogging(option => option.AddSerilog())
                .AddSingleton(Log.Logger)
                .AddSingleton(option => (IConfiguration)configuration)
                .Configure<ConfigurationModel>(configuration.GetSection("OnPremise"))
                .RegisterDependencies()
                .BuildServiceProvider();
        }

        #endregion
    }
}