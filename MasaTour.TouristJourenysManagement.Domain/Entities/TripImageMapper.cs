namespace MasaTour.TouristTripsManagement.Domain.Entities;

[PrimaryKey(nameof(ImageId), nameof(TripId))]
public class TripImageMapper
{
    [MaxLength(36)]
    [MinLength(36)]
    public string ImageId { get; set; }

    [MaxLength(36)]
    [MinLength(36)]
    public string TripId { get; set; }

    public bool IsCover { get; set; }

    [ForeignKey(nameof(TripId))]
    public Trip Trip { get; set; }

    [ForeignKey(nameof(ImageId))]
    public Image Image { get; set; }
}
