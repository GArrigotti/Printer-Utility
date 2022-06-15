using Print_Utility_Core.Architecture.Application_Layer.Extensions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Core.Architecture.Data_Layer.Managers
{
    public abstract class DbManager
    {
        private readonly string dbConnection;
        private readonly ILogger logger;

        #region Constructor:

        public DbManager(string dbConnection, ILogger logger)
        {
            this.dbConnection = dbConnection;
            this.logger = logger.ForContext<DbManager>();
        }

        #endregion

        protected async Task<TType> DbCommand<TType>(Func<IDbConnection, Task<TType>> execute)
        {
            try
            {
                using var connection = new SqlConnection(dbConnection);
                await connection.OpenAsync();

                return await execute(connection);
            }

            catch (Exception exception)
            {
                logger.Decorate(exception);
                throw new Exception(exception.Message);
            }
        }
    }

}
