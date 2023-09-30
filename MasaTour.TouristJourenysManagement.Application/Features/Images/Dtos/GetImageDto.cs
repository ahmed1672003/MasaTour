namespace MasaTour.TouristTripsManagement.Application.Features.Images.Dtos;
public class GetImageDto
{
    public string ImageId { get; set; }
    public string FilePath { get; set; }
    public string ContentType { get; set; }
    public DateTime CreatedAt { get; set; }
}
