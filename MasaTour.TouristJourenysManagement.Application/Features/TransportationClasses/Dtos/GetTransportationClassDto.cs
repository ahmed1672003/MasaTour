namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Dtos;
public class GetTransportationClassDto
{
    public string TrasportationClassId { get; set; }
    public string NameAR { get; set; }
    public string NameDE { get; set; }
    public string NameEN { get; set; }
    public decimal PriceEGPPerKilometer { get; set; }
    public decimal PriceEURPerKilometer { get; set; }
    public decimal PriceUSDPerKilometer { get; set; }
    public decimal PriceGbpPerKilometer { get; set; }
    public string? DescriptionAR { get; set; }
    public string? DescriptionEN { get; set; }
    public string? DescriptionDE { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
