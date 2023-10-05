namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Dtos;
public class GetTripImagesDto
{
    public string ImageId { get; set; }
    public bool IsCover { get; set; }
    public string FilePath { get; set; }
    public string ContentType { get; set; }
    public DateTime CreatedAt { get; set; }
}