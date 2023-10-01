namespace MasaTour.TouristTripsManagement.Application.Features.TripPhases.Dtos;
public class GetTripPhaseDto
{
    public string TripPhaseId { get; set; }
    public int PhaseNumber { get; set; }
    public string LocationNameAR { get; set; }

    public string LocationNameEN { get; set; }

    public string LocationNameDE { get; set; }

    public TimeSpan FromClock { get; set; }

    public TimeSpan ToClock { get; set; }

    public string FromTimeAR { get; set; }

    public string FromTimeEN { get; set; }

    public string FromTimeDE { get; set; }

    public string ToTimeAR { get; set; }

    public string ToTimeEN { get; set; }

    public string ToTimeDE { get; set; }

    public string? DesceiptionAR { get; set; }

    public string? DesceiptionEN { get; set; }

    public string? DesceiptionDE { get; set; }

    public DateTime CreatedAt { get; set; }


    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string TripId { get; set; }
}
