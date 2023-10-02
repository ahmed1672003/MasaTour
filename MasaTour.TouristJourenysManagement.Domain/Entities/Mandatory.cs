using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Domain.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(NameAR), IsUnique = true)]
[Index(nameof(NameEN), IsUnique = true)]
[Index(nameof(NameDE), IsUnique = true)]
public class Mandatory : BaseEntity, ICreateableTracker, IUpdateableTracker, IDeleteableTracker
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

    [AllowNull]
    [MaxLength(3000)]
    public string? DesceiptionEN { get; set; }

    [AllowNull]
    [MaxLength(3000)]
    public string? DesceiptionAR { get; set; }

    [AllowNull]
    [MaxLength(3000)]
    public string? DesceiptionDE { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<TripMandatoryMapper> TripMandatoryMapper { get; set; }
    public Mandatory()
    {
        IsDeleted = false;
        CreatedAt = DateTime.Now;
        TripMandatoryMapper = new(0);
    }
}
