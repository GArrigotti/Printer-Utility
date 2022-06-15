using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Core.Architecture.Domain_Layer.Entities
{
    public class ActiveDirectoryServerEntity
    {
        public string Url { get; set; }

        public NetworkCredential Credentials { get; set; }

        public string Query { get; set; }
    }
}
