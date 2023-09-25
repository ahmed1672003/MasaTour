using System.ComponentModel.DataAnnotations;

namespace MasaTour.TouristJourenysManagement.Application.Features.Auth.Dtos;
public class ConfirmeEmailDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledCanNotBeNull)]
    public string Token { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledCanNotBeNull)]
    [MaxLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsSmallerThanMinLength)]
    public string UserId { get; set; }
}