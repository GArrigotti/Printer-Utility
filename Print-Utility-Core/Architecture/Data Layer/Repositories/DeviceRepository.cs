using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Print_Utility_Core.Architecture.Data_Layer.Contexts;
using Print_Utility_Core.Architecture.Data_Layer.Factories;
using Print_Utility_Core.Architecture.Data_Layer.Managers;
using Print_Utility_Core.Architecture.Data_Layer.Utilities;
using Print_Utility_Core.Architecture.Domain_Layer.Aggregates;
using Print_Utility_Core.Architecture.Domain_Layer.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Core.Architecture.Data_Layer.Repositories
{
    public class DeviceRepository : DbManager, IDeviceRepository
    {
        private bool disposed = false;
        private readonly ILogger logger;
        private readonly IDbFactory factory;
        private readonly IEmbeddedResourceUtility utility;

        #region Constructor:

        public DeviceRepository(IDbFactory factory, IEmbeddedResourceUtility utility, ILogger logger, IOptions<ConfigurationModel> configuration) : base(configuration.Value.DbConnection, logger)
        {
            this.factory = factory;
            this.utility = utility;
            this.logger = logger;
        }

        #endregion

        public async Task<IEnumerable<PrinterAggregate>> GetAllPrinters() => await DbCommand(async db =>
        {
            var query = await utility.Read("Print-Utility-Core.Architecture.Domain Layer.Database.Queries.GetAllPrintersQuery.txt");
            using IDbContext context = factory.Create(db);

            return await context.Retrieve<PrinterAggregate>(query);
        });

        public async Task InsertDevices(ActiveDirectorySearchEntity entity) => await DbCommand(async db =>
        {
            var query = await utility.Read("Print-Utility-Core.Architecture.Domain Layer.Database.Queries.InsertDeviceQuery.txt");
            using IDbContext context = factory.Create(db);

            var parameters = new DynamicParameters();
            parameters.Add("CN", entity.CN);
            parameters.Add("UNCName", entity.UNCName);
            parameters.Add("URL", entity.URL);
            parameters.Add("Server", entity.Server);
            parameters.Add("Path", entity.Path);
            parameters.Add("Driver", entity.Driver);
            parameters.Add("Category", entity.Category);
            parameters.Add("Name", entity.Name);
            parameters.Add("PortName", entity.PortName);
            parameters.Add("Location", entity.Location);

            return await context.Insert(query, parameters);
        });

        public async Task InsertPrinters(PrinterAggregate entity) => await DbCommand(async db =>
        {
            var query = await utility.Read("Print-Utility-Core.Architecture.Domain Layer.Database.Queries.InsertPrinterQuery.txt");
            using IDbContext context = factory.Create(db);

            var parameters = new DynamicParameters();
            parameters.Add("Building", entity.Building);
            parameters.Add("Floor", entity.Floor);
            parameters.Add("Name", entity.Name);
            parameters.Add("Description", entity.Description);
            parameters.Add("Share", entity.Share);

            return await context.Insert(query, parameters);
        });

        public async Task DeleteAllPrinters() => await DbCommand(async db =>
        {
            var query = await utility.Read("Print-Utility-Core.Architecture.Domain Layer.Database.Queries.TruncatePrinterQuery.txt");
            using IDbContext context = factory.Create(db);

            return context.Delete(query);
        });

        public async Task DeleteAllDevices() => await DbCommand(async db =>
        {
            var query = await utility.Read("Print-Utility-Core.Architecture.Domain Layer.Database.Queries.TruncateDeviceQuery.txt");
            using IDbContext context = factory.Create(db);

            return context.Delete(query);
        });

        #region Dispose:

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    #region Interface:

    public interface IDeviceRepository : IDisposable
    {
        Task<IEnumerable<PrinterAggregate>> GetAllPrinters();

        Task InsertDevices(ActiveDirectorySearchEntity entity);

        Task InsertPrinters(PrinterAggregate entity);

        Task DeleteAllPrinters();

        Task DeleteAllDevices();
    }

    #endregion
}
