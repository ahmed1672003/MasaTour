using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Domain.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(NameAR), IsUnique = true)]
[Index(nameof(NameDE), IsUnique = true)]
[Index(nameof(NameEN), IsUnique = true)]
public class TransportationClass : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
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
    public decimal PriceEGPPerKilometer { get; set; }

    [Required]
    public decimal PriceGbpPerKilometer { get; set; }

    [Required]
    public decimal PriceEURPerKilometer { get; set; }

    [Required]
    public decimal PriceUSDPerKilometer { get; set; }

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
    public bool IsDeleted { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public List<Transporation> Transporations { get; set; }


    public TransportationClass()
    {
        IsDeleted = false;
        Transporations = new(0);
    }
}