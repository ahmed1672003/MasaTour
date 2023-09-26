using MasaTour.TouristTripsManagement.Domain.Enums;

namespace MasaTour.TouristTripsManagement.Application.Features.Auth.Dtos;
public class GetUserDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Nationality { get; set; }
    public Gender Gender { get; set; }
    public string ImgSrc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}
