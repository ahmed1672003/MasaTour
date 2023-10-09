namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Dtos;
public class GetTransportationDto
{
    public string TransportationId { get; set; }
    public string Model { get; set; }
    public int NumberOfSeats { get; set; }
    public string DescriptionAR { get; set; }
    public string DescriptionEN { get; set; }
    public string DescriptionDE { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string TransportationClassId { get; set; }
}
