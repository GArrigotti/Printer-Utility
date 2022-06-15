using Print_Utility_Core.Architecture.Application_Layer.Extensions;
using Print_Utility_Core.Architecture.Domain_Layer.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Core.Architecture.Service_Layer
{
    public class ActiveDirectoryService : IActiveDirectoryService
    {
        private bool disposed = false;
        private readonly ILogger logger;

        #region Constructor:

        public ActiveDirectoryService(ILogger logger)
        {
            this.logger = logger;
            this.logger.ForContext<ActiveDirectoryService>();
        }

        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate Platform Compatibility", Justification = "<Pending>")]
        public IEnumerable<SearchResult> Retrieve(ActiveDirectoryServerEntity entity)
        {
            using var entry = new DirectoryEntry(entity.Url)
            {
                Username = entity.Credentials.UserName,
                Password = entity.Credentials.Password
            };

            using var search = new DirectorySearcher(entry);
            search.Filter = entity.Query;

            foreach (SearchResult result in search.FindAll())
                yield return result;
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

    public interface IActiveDirectoryService : IDisposable
    {
        IEnumerable<SearchResult> Retrieve(ActiveDirectoryServerEntity entity);
    }

    #endregion
}
