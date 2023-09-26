using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Domain.Entities;


[PrimaryKey(nameof(Id))]
[Index(nameof(NameAR), IsUnique = true)]
[Index(nameof(NameEN), IsUnique = true)]
[Index(nameof(NameDE), IsUnique = true)]
public class Category : BaseEntity, IDeleteableTracker, IUpdateableTracker, ICreateableTracker
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
    public bool IsActive { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [AllowNull]
    public DateTime? UpdatedAt { get; set; }

    [AllowNull]
    public DateTime? DeletedAt { get; set; }

    [AllowNull]
    [InverseProperty(nameof(CategoriesTripsMapper.Category))]
    public List<CategoriesTripsMapper> CategoriesTripsMappers { get; set; }

    public Category()
    {
        IsDeleted = false;
        CreatedAt = DateTime.Now;
        CategoriesTripsMappers = new List<CategoriesTripsMapper>();
    }
}
