namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
public class UserLogin : IdentityUserLogin<string>
{
    public override string LoginProvider { get; set; }
    public override string ProviderKey { get; set; }
    public override string? ProviderDisplayName { get; set; }
    public override string UserId { get; set; }
}
