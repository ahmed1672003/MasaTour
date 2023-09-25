using MasaTour.TouristJourenysManagement.Domain.Abstracts;

namespace MasaTour.TouristJourenysManagement.Domain.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(Code), IsUnique = true)]
[Index(nameof(NameAR), IsUnique = true)]
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
    public decimal PriceLE { get; set; }  // egyptian

    [Required]
    public decimal PriceUSD { get; set; } // dolar

    [Required]
    public decimal PriceGbp { get; set; } // Gpg

    [Required]
    public bool IsDeleted { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [AllowNull]
    public DateTime? UpdatedAt { get; set; }

    [AllowNull]
    public DateTime? DeletedAt { get; set; }

    [NotMapped]
    public ICollection<CategoriesJourneysMapper>? CategoriesjourneysMappers { get; set; }

    public Journey()
    {
        Id = Guid.NewGuid().ToString();
        IsDeleted = false;
        CategoriesjourneysMappers = new HashSet<CategoriesJourneysMapper>();
    }
}