namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Dtos;
public class AddTransportationDto
{

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledCanNotBeNull)]
    [MaxLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsSmallerThanMinLength)]
    public string TransportationClassId { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsBiggerThanMaxLength)]
    public string Model { get; set; } = "BMW";

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledCanNotBeNull)]
    public int NumberOfSeats { get; set; } = 5;

    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsBiggerThanMaxLength)]
    public string? DescriptionAR { get; set; } = "DesceiptionAr....";

    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsBiggerThanMaxLength)]
    public string? DescriptionEN { get; set; } = "DesceiptionEn....";

    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsBiggerThanMaxLength)]
    public string? DescriptionDE { get; set; } = "DesceiptionDe....";
}
