using Microsoft.Extensions.DependencyInjection;
using Print_Utility_Core.Architecture.Data_Layer.Contexts;
using Print_Utility_Core.Architecture.Data_Layer.Factories;
using Print_Utility_Core.Architecture.Data_Layer.Repositories;
using Print_Utility_Core.Architecture.Data_Layer.Utilities;
using Print_Utility_Core.Architecture.Domain_Layer.Entities;
using Print_Utility_Core.Architecture.Service_Layer.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Desktop.Architecture.Application_Layer.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
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

            services.AddSingleton<IPrintManagerUtility, PrintManagerUtility>();

            return services;
        }
    }
}
