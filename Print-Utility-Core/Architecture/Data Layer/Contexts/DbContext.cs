using Dapper;
using Print_Utility_Core.Architecture.Application_Layer.Extensions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Core.Architecture.Data_Layer.Contexts
{
    public class DbContext : IDbContext
    {
        private bool disposed = false;
        private readonly ILogger logger;
        private readonly IDbConnection dbConnection;

        #region Constructor:

        public DbContext(IDbConnection dbConnection, ILogger logger)
        {
            this.logger = logger.ForContext<DbContext>();
            this.dbConnection = dbConnection;
        }

        #endregion

        public async Task<IEnumerable<TEntity>> Retrieve<TEntity>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                IEnumerable<TEntity> records = parameters != null ?
                    await dbConnection.QueryAsync<TEntity>(query, parameters) :
                    await dbConnection.QueryAsync<TEntity>(query);

                return records;
            }

            catch (Exception exception)
            {
                logger.Decorate(exception);
                throw new Exception($" Failed to retrieve data from {query}...");
            }
        }

        public async Task<int> Insert(string query, DynamicParameters parameters)
        {
            try
            {
                int records = await dbConnection.ExecuteAsync(query, parameters);

                if (records <= 0)
                    logger.Decorate("Failed to insert records...");

                return records;
            }

            catch (Exception exception)
            {
                logger.Decorate(exception);
                throw new Exception($" Failed to insert data from {query}...");
            }
        }

        public async Task Delete(string query, DynamicParameters? parameters = null)
        {
            try
            {
                int records = parameters != null ?
                    await dbConnection.ExecuteAsync(query, parameters) :
                    await dbConnection.ExecuteAsync(query);

                if(records <= 0)
                    logger.Error($" Failed to delete...");
            }

            catch (Exception exception)
            {
                logger.Decorate(exception);
                throw new Exception($" Failed to retrieve data from {query}...");
            }
        }

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

    public interface IDbContext : IDisposable
    {
        Task<IEnumerable<TEntity>> Retrieve<TEntity>(string query, DynamicParameters? parameters = null);

        Task<int> Insert(string query, DynamicParameters parameters);

        Task Delete(string query, DynamicParameters? parameters = null);
    }

    #endregion
}
