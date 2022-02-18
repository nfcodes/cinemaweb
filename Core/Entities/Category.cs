namespace Core.Entities;

public class Category : BaseEntity
{
    public string? CategoryName { get; set; }
    
    // Navigation properties
    public List<MovieCategory> MovieCategories { get; set; } = null!;
}