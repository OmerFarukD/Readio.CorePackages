using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.Graylog;


namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class GraylogLogger : LoggerServiceBase
{
    public GraylogLogger(IConfiguration configuration)
    {
        GraylogConfiguration logConfig = configuration
            .GetSection("SerilogLogConfigurations:GraylogConfiguration")
            .Get<GraylogConfiguration>()
            ?? throw new Exception("You have sent a blank value! Something went wrong. Please try again.");

        Logger = new LoggerConfiguration()
            .WriteTo.Graylog(new GraylogSinkOptions
            {
                HostnameOrAddress = logConfig.Hostname,
                Port = logConfig.Port,
                TransportType =global::Serilog.Sinks.Graylog.Core.Transport.TransportType.Http,
                Facility = logConfig.Facility
            })
            .CreateLogger();
    }

}
