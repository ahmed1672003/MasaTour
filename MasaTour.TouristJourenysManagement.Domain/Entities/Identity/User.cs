using MasaTour.TouristJourenysManagement.Domain.Enums;

namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
public class User : IdentityUser<string>
{
    public override string Id { get; set; }
    public override string UserName { get; set; }
    public override string Email { get; set; }
    public override string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Nationality Nationality { get; set; }
    public string ImgSrc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public IEnumerable<UserJWT> UserJWTs { get; set; }
    public User()
    {
        Id = Guid.NewGuid().ToString();
        UserJWTs = new HashSet<UserJWT>();
        IsDeleted = false;
    }
}
