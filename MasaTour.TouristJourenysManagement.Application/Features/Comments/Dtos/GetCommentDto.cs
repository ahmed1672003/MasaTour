namespace MasaTour.TouristTripsManagement.Application.Features.Comments.Dtos;
public class GetCommentDto
{
    public string CommentId { get; set; }
    public string UserId { get; set; }
    public string TripId { get; set; }
    public string Content { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
