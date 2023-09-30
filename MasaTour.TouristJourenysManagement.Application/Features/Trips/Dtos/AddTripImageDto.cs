namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Dtos;
public class AddTripImageDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsSmallerThanMinLength)]
    public string ImageId { get; set; }
    public bool IsCover { get; set; }
}
