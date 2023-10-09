namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Dtos;
public class UpdateTransportationDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledCanNotBeNull)]
    [MaxLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsSmallerThanMinLength)]
    public string TransportationId { get; set; } = "714EB8C5-F051-46FC-9F71-3576D02B2821";

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledCanNotBeNull)]
    [MaxLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsSmallerThanMinLength)]
    public string TransportationClassId { get; set; } = "714EB8C5-F051-46FC-9F71-3576D02B2821";

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsBiggerThanMaxLength)]
    public string Model { get; set; } = "BMW";

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledCanNotBeNull)]
    public int NumberOfSeats { get; set; } = 5;

    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsBiggerThanMaxLength)]
    public string DesceiptionAR { get; set; } = "DesceiptionAr....";

    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsBiggerThanMaxLength)]
    public string DesceiptionEN { get; set; } = "DesceiptionEn....";

    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Transportation.FiledLengthIsBiggerThanMaxLength)]
    public string DesceiptionDE { get; set; } = "DesceiptionDe....";

}
