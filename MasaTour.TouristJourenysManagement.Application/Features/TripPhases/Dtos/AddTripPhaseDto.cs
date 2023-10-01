namespace MasaTour.TouristTripsManagement.Application.Features.TripPhases.Dtos;
public class AddTripPhaseDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    public int PhaseNumber { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledLengthIsBiggerThanMaxLength)]
    public string LocationNameAR { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledLengthIsBiggerThanMaxLength)]
    public string LocationNameEN { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledLengthIsBiggerThanMaxLength)]
    public string LocationNameDE { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    public int FromHours { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    public int FromMinutes { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    public int ToHours { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    public int ToMinutes { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledLengthIsBiggerThanMaxLength)]
    public string FromTimeAR { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledLengthIsBiggerThanMaxLength)]
    public string FromTimeEN { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledLengthIsBiggerThanMaxLength)]
    public string FromTimeDE { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledLengthIsBiggerThanMaxLength)]
    public string ToTimeAR { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledLengthIsBiggerThanMaxLength)]
    public string ToTimeEN { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TripPhase.FiledLengthIsBiggerThanMaxLength)]
    public string ToTimeDE { get; set; }

    [MaxLength(3000)]
    public string? DesceiptionAR { get; set; }

    [MaxLength(3000)]
    public string? DesceiptionEN { get; set; }

    [MaxLength(3000)]
    public string? DesceiptionDE { get; set; }
}
