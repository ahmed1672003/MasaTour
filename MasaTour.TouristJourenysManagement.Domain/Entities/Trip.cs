using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Domain.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(Code), IsUnique = true)]
[Index(nameof(NameAR), IsUnique = true)]
[Index(nameof(NameEN), IsUnique = true)]
[Index(nameof(NameDE), IsUnique = true)]
public class Trip : BaseEntity, IDeleteableTracker, IUpdateableTracker, ICreateableTracker
{
    [Required]
    [MaxLength(255)]
    public string Code { get; set; }

    [Required]
    [MaxLength(255)]
    public string NameAR { get; set; }

    [Required]
    [MaxLength(255)]
    public string NameEN { get; set; }

    [Required]
    [MaxLength(255)]
    public string NameDE { get; set; }

    [MaxLength(3000)]
    public string? LongDesceiptionAR { get; set; }

    [MaxLength(3000)]
    public string? LongDesceiptionEN { get; set; }

    [MaxLength(3000)]
    public string? LongDesceiptionDE { get; set; }

    [Required]
    [MaxLength(1500)]
    public string MiniDesceiptionAR { get; set; }

    [Required]
    [MaxLength(1500)]
    public string MiniDesceiptionEN { get; set; }

    [Required]
    [MaxLength(1500)]
    public string MiniDesceiptionDE { get; set; }

    [Required]
    [MaxLength(255)]
    public string FromAR { get; set; }

    [Required]
    [MaxLength(255)]
    public string FromEN { get; set; }

    [Required]
    [MaxLength(255)]
    public string FromDE { get; set; }

    [Required]
    [MaxLength(255)]
    public string ToAR { get; set; }

    [Required]
    [MaxLength(255)]
    public string ToEN { get; set; }

    [Required]
    [MaxLength(255)]
    public string ToDE { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public decimal PriceEGP { get; set; }

    [Required]
    public decimal PriceUSD { get; set; }

    [Required]
    public decimal PriceGBP { get; set; }

    [Required]
    public decimal PriceEUR { get; set; }

    [Required]
    public bool IsFamous { get; set; }


    [Required]
    public bool IsActive { get; set; }

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

    public Trip()
    {
        IsDeleted = false;
    }
}