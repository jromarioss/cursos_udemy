namespace ApiCatalago.Pagination;

public class QueryStringParameters
{
    const int maxPageSize = 50;
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get { return _pageSize; } // retorna o tamanho da página
        // antes de atribuir um valor veja se é maior que a maxPageSize se não retorna 50
        set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
    }
}
