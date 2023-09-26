using System.ComponentModel.DataAnnotations;

namespace MasaTour.TouristTripsManagement.Application.Features.Auth.Dtos;
public class ChangePassowrdDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsSmallerThanMinLength)]
    public string EmailOrUserName { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsSmallerThanMinLength)]
    public string CurrentPassword { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsSmallerThanMinLength)]
    public string Password { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledLengthIsSmallerThanMinLength)]
    [Compare(nameof(Password), ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.PasswordDoesNotMatchedWithConfilremdPassword)]
    public string ConfirmedPassword { get; set; }
}
