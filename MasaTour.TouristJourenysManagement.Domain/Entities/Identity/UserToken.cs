namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
public class UserToken : IdentityUserToken<string>
{
    public override string UserId { get; set; }
    public override string LoginProvider { get; set; }
    public override string? Name { get; set; }
    public override string? Value { get; set; }
}
