namespace Core.ElasticSearch.Models;

public sealed class ElasticSearchInsertManyModel : ElasticSearchModel
{
    public object[] Items { get; set; }
}
