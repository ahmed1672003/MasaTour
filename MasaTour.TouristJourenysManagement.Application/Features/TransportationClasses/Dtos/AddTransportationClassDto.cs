using System.Diagnostics.CodeAnalysis;

namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Dtos;
public class AddTransportationClassDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledLengthIsSmallerThanMinLength)]
    public string NameAR { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledLengthIsSmallerThanMinLength)]
    public string NameEN { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledLengthIsSmallerThanMinLength)]
    public string NameDE { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledCanNotBeNull)]
    public decimal PriceEGPPerKilometer { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledCanNotBeNull)]
    public decimal PriceGbpPerKilometer { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledCanNotBeNull)]
    public decimal PriceEURPerKilometer { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledCanNotBeNull)]
    public decimal PriceUSDPerKilometer { get; set; }

    [AllowNull]
    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledLengthIsBiggerThanMaxLength)]
    public string? DescriptionAR { get; set; }

    [AllowNull]
    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledLengthIsBiggerThanMaxLength)]
    public string? DescriptionEN { get; set; }

    [AllowNull]
    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.TransportationClass.FiledLengthIsBiggerThanMaxLength)]
    public string? DescriptionDE { get; set; }
}
