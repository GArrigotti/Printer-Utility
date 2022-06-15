using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Core.Architecture.Domain_Layer.Aggregates
{
    public class PrinterAggregate
    {
        public int Id { get; set; }

        public string Building { get; set; }

        public string Floor { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Share { get; set; }
    }
}
