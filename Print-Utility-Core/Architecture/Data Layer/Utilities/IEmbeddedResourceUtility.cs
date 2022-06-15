using Print_Utility_Core.Architecture.Application_Layer.Extensions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Core.Architecture.Data_Layer.Utilities
{
    public class EmbeddedResourceUtility : IEmbeddedResourceUtility
    {
        private readonly ILogger logger;

        #region Constructor:

        public EmbeddedResourceUtility(ILogger logger) => this.logger = logger;

        #endregion

        public async Task<string> Read(string resource)
        {
            if (string.IsNullOrEmpty(resource))
            {
                logger.Decorate($@" Error with resource: {resource.Split("Database")[1]}...");
                throw new ArgumentNullException(resource);
            }

            try
            {
                if (resource.Contains("-"))
                    resource = String.Join("_", resource.Split("-"));

                if (resource.Contains(" "))
                    resource = String.Join("_", resource.Split(' '));

                using Stream stream = typeof(EmbeddedResourceUtility).GetTypeInfo().Assembly.GetManifestResourceStream(resource);
                using var reader = new StreamReader(stream);
                return await reader.ReadToEndAsync();
            }

            catch (Exception exception)
            {
                logger.Decorate(exception);
                throw new Exception("Failed to parse embedded resource...");
            }
        }
    }

    #region Interface:

    public interface IEmbeddedResourceUtility
    {
        Task<string> Read(string resource);
    }
    #endregion
}
