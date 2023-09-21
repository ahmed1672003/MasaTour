using MasaTour.TouristJourenysManagement.Domain.Enums;
namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Dtos;
public class AddUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public Nationality Nationality { get; set; }
    public string ImgSrc { get; set; }
    public string Password { get; set; }
    public string ConfirmedPassword { get; set; }
}
