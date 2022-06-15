using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Core.Architecture.Domain_Layer.Entities
{
    public class ConfigurationModel
    {
        public string DbConnection { get; set; }

        public string Url { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Domain { get; set; }
    }
}
