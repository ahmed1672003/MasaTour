namespace MasaTour.TouristTripsManagement.Domain.Mandatories.Dtos;
public class AddMandatoryDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledLengthIsSmallerThanMinLength)]
    public string NameAR { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledLengthIsSmallerThanMinLength)]
    public string NameEN { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledLengthIsSmallerThanMinLength)]
    public string NameDE { get; set; }

    [MaxLength(3000, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledLengthIsBiggerThanMaxLength)]
    public string? DesceiptionEN { get; set; }

    [MaxLength(3000, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledLengthIsBiggerThanMaxLength)]
    public string? DesceiptionAR { get; set; }

    [MaxLength(3000, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Mandatory.FiledLengthIsBiggerThanMaxLength)]
    public string? DesceiptionDE { get; set; }
}
