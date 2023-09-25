using MasaTour.TouristJourenysManagement.Domain.Abstracts;

namespace MasaTour.TouristJourenysManagement.Domain.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(NameAR), IsUnique = true)]
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

    [NotMapped]
    public ICollection<CategoriesJourneysMapper>? CategoriesjourneysMappers { get; set; }

    public Category()
    {
        Id = Guid.NewGuid().ToString();
        IsDeleted = false;
        CreatedAt = DateTime.Now;
        CategoriesjourneysMappers = new HashSet<CategoriesJourneysMapper>();
    }
}
