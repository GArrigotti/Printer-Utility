using Print_Utility_Core.Architecture.Domain_Layer.Aggregates;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Print_Utility_Core.Architecture.Application_Layer.Extensions;

namespace Print_Utility_Core.Architecture.Service_Layer.Utilities
{
    public class PrintManagerUtility : IPrintManagerUtility
    {
        private readonly ILogger logger;

        #region Constructor:

        public PrintManagerUtility(ILogger logger) => this.logger = logger;

        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate Platform Compatibility", Justification = "<Pending>")]
        public bool AddPrinter(PrinterAggregate printer)
        {
            try
            {
                using var manager = new ManagementClass("WIN32_Printer");
                using var device = manager.GetMethodParameters("AddPrinterConnection");

                device.SetPropertyValue("Name", printer.Share);

                var output = (ManagementBaseObject)manager.InvokeMethod("AddPrinterConnection", device, null);
                var code = (uint)output.Properties["returnValue"].Value;

                return code != 0 ? false : true;
            }

            catch(Exception exception)
            {
                logger.Decorate(exception);
                return false;
            }
        }
    }

    #region Interface:

    public interface IPrintManagerUtility
    {
        bool AddPrinter(PrinterAggregate printer);
    }

    #endregion
}
