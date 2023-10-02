using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Domain.Entities;

[PrimaryKey(nameof(Id))]
public class Image : BaseEntity, ICreateableTracker
{
    [Required]
    [MaxLength(1500)]
    public string FileName { get; set; }

    [Required]
    [MaxLength(255)]
    public string ContentType { get; set; }

    [Required]
    [MaxLength(3000)]
    public string FilePath { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public List<TripImageMapper> TripImageMapper { get; set; }
    public Image()
    {
        TripImageMapper = new(0);
    }
}
