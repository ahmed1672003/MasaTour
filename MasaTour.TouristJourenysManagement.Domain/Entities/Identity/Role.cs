namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;

[PrimaryKey(nameof(Id))]
public class Role : IdentityRole<string>
{
    [MaxLength(36)]
    public override string Id { get; set; }

    [Required]
    [MaxLength(255)]
    public override string Name { get; set; }

    [AllowNull]
    public List<RoleClaim> RoleClaims { get; set; }

    [AllowNull]
    [InverseProperty(nameof(UserRoleMapper.Role))]
    public List<UserRoleMapper> UserRoleMappers { get; set; }
    public Role()
    {
        Id = Guid.NewGuid().ToString();
        RoleClaims = new List<RoleClaim>();
        UserRoleMappers = new List<UserRoleMapper>();
    }
}
