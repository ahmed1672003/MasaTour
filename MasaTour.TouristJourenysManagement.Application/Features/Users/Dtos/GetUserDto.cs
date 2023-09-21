namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Dtos;
public class GetUserDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string ImgSrc { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
    public string DeletedAt { get; set; }
}
