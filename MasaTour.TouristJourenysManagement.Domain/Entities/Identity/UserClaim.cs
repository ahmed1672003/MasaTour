using System.ComponentModel.DataAnnotations.Schema;

namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
public class UserClaim : IdentityUserClaim<string>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }
    public override string UserId { get; set; }
    public override string ClaimType { get; set; }
    public override string ClaimValue { get; set; }
}
