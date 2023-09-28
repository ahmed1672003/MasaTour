using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Domain.Entities;

[PrimaryKey(nameof(MandatoryId), nameof(TripId))]
public class TripMandatoryMapper : ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [MaxLength(36)]
    [MinLength(36)]
    public string MandatoryId { get; set; }

    [MaxLength(36)]
    [MinLength(36)]
    public string TripId { get; set; }


    [ForeignKey(nameof(MandatoryId))]
    public Mandatory Mandatory { get; set; }


    [ForeignKey(nameof(TripId))]
    public Trip Trip { get; set; }


    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public TripMandatoryMapper()
    {
        CreatedAt = DateTime.Now;
        IsDeleted = false;
    }
}
