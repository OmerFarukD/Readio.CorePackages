
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns;

public static class CrossCuttingConcernsServiceRegistration
{
    public static IServiceCollection AddSerilogDependencies(this IServiceCollection services, LogType logType)
    {
        return logType switch
        {
            LogType.MSSQL => services.AddSingleton<LoggerServiceBase, MsSqlLogger>(),
            LogType.FILE => services.AddSingleton<LoggerServiceBase, FileLogger>(),
            LogType.ELASTICSEARCH => services.AddSingleton<LoggerServiceBase, ElasticSearchLogger>(),
            LogType.GRAYLOG => services.AddSingleton<LoggerServiceBase,GraylogLogger>()
        };
    }

}
