using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Print_Utility_CLI.Architecture.Application_Layer.Extensions;
using Print_Utility_Core.Architecture.Application_Layer.Extensions;
using Print_Utility_Core.Architecture.Data_Layer.Repositories;
using Print_Utility_Core.Architecture.Domain_Layer.Aggregates;
using Print_Utility_Core.Architecture.Domain_Layer.Entities;
using Print_Utility_Core.Architecture.Service_Layer;
using Serilog;
using System.DirectoryServices;
using System.Net;

var start = DateTime.UtcNow;
var invalid = new List<string>();

try
{
    var application = WebApplication.CreateBuilder(args);
    application.Host.RegisterLogger();

    Log.Information($"┌{new string('─', 100)}┐");
    Log.Information($" Starting Application {start:MMMM dd, yyyy hh:mm:ss}");
    Log.Information($" Configuring Configuration Manager and IServiceCollection");

    application.Configuration.Build("cli-application-settings.json");
    application.Services.RegisterDependencies();

    Log.Information($" Serialize Azure Information...");
    application.Services.Configure<ConfigurationModel>(application.Configuration.GetSection("OnPremise"));

    Log.Information(" Building Services...");
    using var services = application.Services.BuildServiceProvider();

    Log.Information(" Pull Printers From Active Directory...");
    var configuration = services.GetService<IOptions<ConfigurationModel>>();
    var ldap = services.GetService<IActiveDirectoryService>();
    var repository = services.GetService<IDeviceRepository>();

    Log.Information(" Cleanup Devices and Printers From Active Directory...");
    await Task.WhenAll(
        repository.DeleteAllDevices(),
        repository.DeleteAllPrinters()
    );

    IEnumerable<SearchResult> printers = ldap.Retrieve(new ActiveDirectoryServerEntity()
    {
        Url = configuration.Value.Url,
        Credentials = new NetworkCredential(configuration.Value.Username, configuration.Value.Password, configuration.Value.Domain),
        Query = $"(objectCategory=PrintQueue)"
    });

    var devices = new List<ActiveDirectorySearchEntity>();
    foreach (var printer in printers)
        devices.Add(new ActiveDirectorySearchEntity(printer));

    foreach (var device in devices)
    {
        #region Conditional Annotation Verification:

        if (device.Location == null)
        {
            Log.Error($" {device.Name} Not Annotated...");
            invalid.Add(device.Name);
            continue;
        }

        var filter = device.Location.Split('|');
        if (filter.Count() < 2)
        {
            Log.Error($" {device.Name} Not Annotated...");
            invalid.Add(device.Name);
            continue;
        }

        #endregion

        var printer = new PrinterAggregate()
        {
            Building = filter[0],
            Floor = filter[1],
            Name = device.Name,
            Description = filter[2],
            Share = device.UNCName
        };

        Log.Information($" Insert Device {device.Name} to Database...");
        await Task.WhenAll(
            repository.InsertDevices(device),
            repository.InsertPrinters(printer)
        );
    }

    Log.Information($" Time Elapsed: {DateTime.UtcNow.Subtract(start).Seconds} Seconds...");
    Log.Information($" Application Completed {DateTime.UtcNow:MMMM dd, yyyy hh:mm:ss}");
    Log.Information($"└{new string('─', 100)}┘");
}

catch(Exception exception)
{
    Log.Logger.Decorate(exception);
    Log.Information($" Time Elapsed: {DateTime.UtcNow.Subtract(start).Seconds} Seconds...");
    Log.Information($" Application Stopped Abruptly {DateTime.UtcNow:MMMM dd, yyyy hh:mm:ss}");
    Log.Information($"└{new string('─', 100)}┘");
    Environment.Exit(1);
}