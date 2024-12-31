namespace Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;

public class ElasticSearchConfiguration
{
    /// <summary>
    /// Elasticsearch endpoint'i (örn: "http://localhost:9200" veya "https://elasticserver:9200")
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Log indekslerinin adı ve tarih formatı (örn: "myapp-logs-{0:yyyy.MM.dd}")
    /// </summary>
    public string IndexFormat { get; set; } = "myapp-logs-{0:yyyy.MM.dd}";

    /// <summary>
    /// Elasticsearch template otomatik kaydı
    /// </summary>
    public bool AutoRegisterTemplate { get; set; } = true;

    /// <summary>
    /// Opsiyonel: Kimlik doğrulama veya diğer ayarlar gerekirse eklenecek alanlar
    /// </summary>
    // public string Username { get; set; }
    // public string Password { get; set; }
    // public bool UseSSL { get; set; }
}