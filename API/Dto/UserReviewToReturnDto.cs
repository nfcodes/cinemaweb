namespace API.Dto;

public class UserReviewToReturnDto
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime? ReviewDate { get; set; }
}