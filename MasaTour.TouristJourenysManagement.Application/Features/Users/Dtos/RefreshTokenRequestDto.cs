using System.ComponentModel.DataAnnotations;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Dtos;
public class RefreshTokenRequestDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledCanNotBeNull)]
    public string JWT { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.User.FiledCanNotBeNull)]
    public string RefreshToken { get; set; }
}
