

namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;

[PrimaryKey(nameof(Id))]
public class UserClaim : IdentityUserClaim<string>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [Required]
    [MaxLength(36)]
    public override string UserId { get; set; }

    [Required]
    [MaxLength(255)]
    public override string ClaimType { get; set; }

    [Required]
    [MaxLength(255)]
    public override string ClaimValue { get; set; }

}
