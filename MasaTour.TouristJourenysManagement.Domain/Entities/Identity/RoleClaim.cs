namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
public class RoleClaim : IdentityRoleClaim<string>
{
    public override int Id { get; set; }
    public override string RoleId { get; set; }
    public override string ClaimType { get; set; }
    public override string ClaimValue { get; set; }
}
