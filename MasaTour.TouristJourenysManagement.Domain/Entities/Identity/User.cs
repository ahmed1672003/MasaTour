using MasaTour.TouristJourenysManagement.Domain.Abstracts;

namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;

[PrimaryKey(nameof(Id))]
[Index(nameof(UserName), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User : IdentityUser<string>, IDeleteableTracker, IUpdateableTracker, ICreateableTracker
{
    [MaxLength(36)]
    public override string Id { get; set; }

    [Required]
    [MaxLength(255)]
    public override string UserName { get; set; }

    [Required]
    [MaxLength(255)]
    public override string Email { get; set; }

    [Required]
    [MaxLength(255)]
    public override string PhoneNumber { get; set; }

    [Required]
    [MaxLength(255)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(255)]
    public string LastName { get; set; }

    [Required]
    public string Nationality { get; set; }

    public Gender Gender { get; set; }

    [Required]
    [MaxLength(1500)]
    public string ImgSrc { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [AllowNull]
    public DateTime? UpdatedAt { get; set; }

    [AllowNull]
    public DateTime? DeletedAt { get; set; }

    [AllowNull]
    public List<UserJWT> UserJWTs { get; set; }

    [AllowNull]
    [InverseProperty(nameof(UserRoleMapper.User))]
    public List<UserRoleMapper> UserRoles { get; set; }

    public User()
    {
        Id = Guid.NewGuid().ToString();
        IsDeleted = false;
        CreatedAt = DateTime.Now;
        UserJWTs = new List<UserJWT>();
        UserRoles = new List<UserRoleMapper>();
    }
}
