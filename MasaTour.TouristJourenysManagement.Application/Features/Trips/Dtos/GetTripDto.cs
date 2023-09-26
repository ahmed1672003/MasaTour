namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Dtos;
public class GetTripDto
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string NameAR { get; set; }
    public string NameEN { get; set; }
    public string NameDE { get; set; }
    public string? LongDesceiptionAR { get; set; }
    public string? LongDesceiptionEN { get; set; }
    public string? LongDesceiptionDE { get; set; }
    public string MiniDesceiptionAR { get; set; }
    public string MiniDesceiptionEN { get; set; }
    public string MiniDesceiptionDE { get; set; }
    public string FromAR { get; set; }
    public string FromEN { get; set; }
    public string FromDE { get; set; }
    public string ToAR { get; set; }
    public string ToEN { get; set; }
    public string ToDE { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal PriceEGP { get; set; }
    public decimal PriceUSD { get; set; }
    public decimal PriceGBP { get; set; }
    public decimal PriceEUR { get; set; }
    public bool IsFamous { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
