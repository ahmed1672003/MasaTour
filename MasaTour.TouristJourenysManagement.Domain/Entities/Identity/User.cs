using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;

using MasaTour.TouristJourenysManagement.Domain.Enums;

using Microsoft.EntityFrameworkCore;

namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;

[PrimaryKey(nameof(Id))]
[Index(nameof(UserName), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User : IdentityUser<string>
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
    public Nationality Nationality { get; set; }

    [Required]
    [MaxLength(1500)]
    public string ImgSrc { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    [AllowNull]
    public IEnumerable<UserJWT> UserJWTs { get; set; }

    [AllowNull]
    public IEnumerable<UserRoleMapper> UserRoles { get; set; }

    public User()
    {
        Id = Guid.NewGuid().ToString();
        IsDeleted = false;
        Nationality = Nationality.Egyptian;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        UserName = new MailAddress(Email).User;
        UserJWTs = new HashSet<UserJWT>();
        UserRoles = new HashSet<UserRoleMapper>();
    }
}
