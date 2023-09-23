using System.ComponentModel.DataAnnotations;

namespace MasaTour.TouristJourenysManagement.Application.Features.Auth.Dtos;
public class LoginUserDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(5, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsSmallerThanMinLength)]
    public string EmailOrUserName { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsSmallerThanMinLength)]
    public string Password { get; set; }
}
