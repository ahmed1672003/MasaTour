using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Domain.Entities.Identity;

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

    [Required]
    public Gender Gender { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    [MaxLength(1500)]
    public string? FileName { get; set; }

    [MaxLength(3000)]
    public string? FilePath { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
    public List<UserJWT> UserJWTs { get; set; }
    public List<UserRoleMapper> UserRoles { get; set; }
    public List<Comment> Comments { get; set; }


    public User()
    {
        Id = Guid.NewGuid().ToString();
        IsDeleted = false;
        CreatedAt = DateTime.Now;
        UserJWTs = new(0);
        UserRoles = new(0);
        Comments = new(0);
    }
}
