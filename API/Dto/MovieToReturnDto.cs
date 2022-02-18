namespace API.Dto;

public class MovieToReturnDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
    public string PictureUrl { get; set; }
    public int Rating { get; set; }
    public int ReleaseYear { get; set; }

    public IEnumerable<CategoryToReturnDto> Categories { get; set; } = null!;
    public IEnumerable<UserReviewToReturnDto> UserReviews { get; set; } = null!;
}