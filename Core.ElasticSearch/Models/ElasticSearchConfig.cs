namespace Core.ElasticSearch.Models;

public sealed class ElasticSearchConfig
{
    public string ConnectionString { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
