using Print_Utility_Core.Architecture.Data_Layer.Contexts;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Core.Architecture.Data_Layer.Factories
{
    public class DbFactory : IDbFactory
    {
        private readonly ILogger logger;

        #region Constructor:

        public DbFactory(ILogger logger) => this.logger = logger;

        #endregion

        public IDbContext Create(IDbConnection dbConnection) => new DbContext(dbConnection, logger);
    }

    #region Interface:

    public interface IDbFactory
    {
        IDbContext Create(IDbConnection dbConnection);
    }

    #endregion
}
