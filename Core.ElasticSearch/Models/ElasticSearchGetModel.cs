namespace Core.ElasticSearch.Models;

public sealed class ElasticSearchGetModel<T>
{
    public string ElasticId { get; set; }
    public T Item { get; set; }
}
