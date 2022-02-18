namespace Core.Entities;

public class UserReview : BaseEntity
{
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime? ReviewDate { get; set; }
    
    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public int MovieId { get; set; }
}