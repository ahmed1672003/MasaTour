using MasaTour.TouristJourenysManagement.Domain.Abstracts;

namespace MasaTour.TouristJourenysManagement.Domain.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(Code), IsUnique = true)]
[Index(nameof(NameAR), IsUnique = true)]
[Index(nameof(NameEN), IsUnique = true)]
[Index(nameof(NameDE), IsUnique = true)]
public class Journey : BaseEntity, IDeleteableTracker, IUpdateableTracker
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

    [Required]
    [MaxLength(3000)]
    public string LongDesceiptionAR { get; set; }

    [Required]
    [MaxLength(3000)]
    public string LongDesceiptionEN { get; set; }

    [Required]
    [MaxLength(3000)]
    public string LongDesceiptionDE { get; set; }

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
    public decimal PriceLE { get; set; }

    [Required]
    public decimal PriceUSD { get; set; }

    [Required]
    public decimal PriceGBP { get; set; }

    [Required]
    public decimal PriceEUR { get; set; }


    [Required]
    public bool IsDeleted { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [AllowNull]
    public DateTime? UpdatedAt { get; set; }

    [AllowNull]
    public DateTime? DeletedAt { get; set; }

    [AllowNull]
    [InverseProperty(nameof(CategoriesJourneysMapper.Journey))]
    public List<CategoriesJourneysMapper> CategoriesjourneysMappers { get; set; }

    public Journey()
    {
        IsDeleted = false;
        CategoriesjourneysMappers = new List<CategoriesJourneysMapper>();
    }
}