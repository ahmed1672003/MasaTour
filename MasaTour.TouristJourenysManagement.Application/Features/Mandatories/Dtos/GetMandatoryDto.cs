namespace MasaTour.TouristTripsManagement.Domain.Mandatories.Dtos;
public class GetMandatoryDto
{
    public string MandatoryId { get; set; }
    public string NameAR { get; set; }

    public string NameEN { get; set; }

    public string NameDE { get; set; }

    public string? DesceiptionEN { get; set; }

    public string? DesceiptionAR { get; set; }

    public string? DesceiptionDE { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
