using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.Elasticsearch;


namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class ElasticSearchLogger : LoggerServiceBase
{
    public ElasticSearchLogger(IConfiguration configuration)
    {
        ElasticSearchConfiguration logConfig = configuration
            .GetSection("SerilogLogConfigurations:ElasticSearchConfiguration")
            .Get<ElasticSearchConfiguration>()
            ?? throw new Exception("You have sent a blank value! Something went wrong. Please try again.");

        // Elasticsearch opsiyonları
        var elasticSinkOptions = new ElasticsearchSinkOptions(new Uri(logConfig.Url))
        {
            AutoRegisterTemplate = logConfig.AutoRegisterTemplate,
            IndexFormat = logConfig.IndexFormat,

            // Burada ek parametre ayarlayabilirsiniz, örn:
            // ModifyConnectionSettings = x => x.BasicAuthentication(logConfig.Username, logConfig.Password)
            // PipelineName = "my-custom-pipeline"
            // NumberOfShards = 2
            // NumberOfReplicas = 1
        };

        Logger = new LoggerConfiguration()
            .WriteTo.Elasticsearch(elasticSinkOptions)
            .CreateLogger();
    }
}