namespace Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;

public class GraylogConfiguration
{
    /// <summary>
    /// Graylog sunucu adresi, örnek: "localhost" veya "192.168.1.10"
    /// </summary>
    public string Hostname { get; set; } = string.Empty;

    /// <summary>
    /// Graylog'da genelde varsayılan 12201 portu kullanılır
    /// </summary>
    public int Port { get; set; } = 12201;


    /// <summary>
    /// Graylog üzerinde "facility" alanı, hangi uygulamadan log geldiğini belirtmek için kullanılır
    /// </summary>
    public string Facility { get; set; } = "MyAppFacility";
}


public enum TransportType
{
    Udp,
    Tcp,
    Http
}