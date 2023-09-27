using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Domain.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(NameAR), IsUnique = true)]
[Index(nameof(NameEN), IsUnique = true)]
[Index(nameof(NameDE), IsUnique = true)]
public class SubCategory : BaseEntity, ICreateableTracker, IUpdateableTracker, IDeleteableTracker
{
    [Required]
    [MaxLength(255)]
    public string NameAR { get; set; }

    [Required]
    [MaxLength(255)]
    public string NameEN { get; set; }

    [Required]
    [MaxLength(255)]
    public string NameDE { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [AllowNull]
    public DateTime? UpdatedAt { get; set; }

    [AllowNull]
    public DateTime? DeletedAt { get; set; }

    [Required]
    [MaxLength(36)]
    [MinLength(36)]
    public string CategoryId { get; set; }

    [AllowNull]
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }

    [AllowNull]
    public List<Trip> Trips { get; set; }

    public SubCategory()
    {
        IsDeleted = false;
        CreatedAt = DateTime.Now;
        Trips = new List<Trip>();
    }
}
