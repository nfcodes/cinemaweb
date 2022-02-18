namespace Core.Specifications;

public class MovieSpecificationParams
{
    private const int MaxPageSize = 6;

    public int PageIndex { get; set; } = 1;
    public int? MinRating { get; set; }
    public List<int>? CategoriesId { get; set; }
    public string? Sort { get; set; }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = Math.Min(MaxPageSize, value);
    }
    
    public string Search
    {
        get => _search;
        set => _search = value.ToLower();
    }

    private int _pageSize = 5;
    private string _search = string.Empty;
}