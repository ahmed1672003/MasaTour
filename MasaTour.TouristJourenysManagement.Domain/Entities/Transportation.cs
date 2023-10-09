using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Domain.Entities;
[PrimaryKey(nameof(Id))]
public class Transportation : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(255)]
    public string Model { get; set; }

    [Required]
    public int NumberOfSeats { get; set; }

    [AllowNull]
    [MaxLength(1500)]
    public string? DescriptionAR { get; set; }

    [AllowNull]
    [MaxLength(1500)]
    public string? DescriptionEN { get; set; }

    [AllowNull]
    [MaxLength(1500)]
    public string? DescriptionDE { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [Required]
    [MaxLength(36)]
    [MinLength(36)]
    public string TransporationClassId { get; set; }

    [ForeignKey(nameof(TransporationClassId))]
    public TransportationClass TransporationClass { get; set; }
    public Transportation() => IsDeleted = false;
}
