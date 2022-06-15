using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Core.Architecture.Domain_Layer.Entities
{
    public class ActiveDirectorySearchEntity
    {
        #region Constructor:

        public ActiveDirectorySearchEntity(SearchResult entity) => Map(entity);

        #endregion

        public string CN { get; set; }

        public string UNCName { get; set; }

        public string URL { get; set; }

        public string Server { get; set; }

        public string Path { get; set; }

        public string Driver { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string PortName { get; set; }

        public string Location { get; set; }

        #region Private:

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate Platform Compatibility", Justification = "<Pending>")]
        private void Map(SearchResult search)
        {
            foreach (var entry in search.Properties.PropertyNames)
                foreach (var value in search.Properties[$"{entry}"])
                    switch (entry)
                    {
                        case "cn":
                            CN = $"{value}";
                            break;

                        case "uncname":
                            UNCName = $"{value}";
                            break;

                        case "url":
                            URL = $"{value}";
                            break;

                        case "servername":
                            Server = $"{value}";
                            break;

                        case "adspath":
                            Path = $"{value}";
                            break;

                        case "drivername":
                            Driver = $"{value}";
                            break;

                        case "objectcategory":
                            Category = $"{value}";
                            break;

                        case "printername":
                            Name = $"{value}";
                            break;

                        case "portname":
                            PortName = $"{value}";
                            break;

                        case "location":
                            Location = $"{value}";
                            break;

                        default:
                            break;
                    }                
        }

        #endregion
    }
}
