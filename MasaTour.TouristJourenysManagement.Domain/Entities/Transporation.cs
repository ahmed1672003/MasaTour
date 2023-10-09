using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Domain.Entities;
[PrimaryKey(nameof(Id))]
public class Transporation : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(255)]
    public string ModelAR { get; set; }

    [Required]
    [MaxLength(255)]
    public string ModelEN { get; set; }

    [Required]
    [MaxLength(255)]
    public string ModelDE { get; set; }

    [Required]
    public int NumberOfSeats { get; set; }

    [AllowNull]
    [MaxLength(1500)]
    public string? DesceiptionAR { get; set; }

    [AllowNull]
    [MaxLength(1500)]
    public string? DesceiptionEN { get; set; }

    [AllowNull]
    [MaxLength(1500)]
    public string? DesceiptionDE { get; set; }

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

    public Transporation() => IsDeleted = false;
}
