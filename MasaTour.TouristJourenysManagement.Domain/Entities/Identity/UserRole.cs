namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
public class UserRole : IdentityUserRole<string>
{
    public override string UserId { get; set; }
    public override string RoleId { get; set; }
}
