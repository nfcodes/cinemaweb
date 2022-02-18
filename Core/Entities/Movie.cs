namespace Core.Entities;

public class Movie : BaseEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Director { get; set; }
    public string? PictureUrl { get; set; }
    public int Rating { get; set; }
    public int ReleaseYear { get; set; }

    // Navigation properties
    public IEnumerable<MovieCategory> MovieCategories { get; set; } = null!;
    public IEnumerable<UserReview> UserReviews { get; set; } = null!;
}