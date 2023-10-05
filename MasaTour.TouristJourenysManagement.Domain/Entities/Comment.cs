using MasaTour.TouristTripsManagement.Domain.Abstracts;
using MasaTour.TouristTripsManagement.Domain.Entities.Identity;

namespace MasaTour.TouristTripsManagement.Domain.Entities;

[PrimaryKey(nameof(Id))]
public class Comment : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [MaxLength(1500)]
    public string Content { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime CreatedAt { get; set; }

    [Required]
    [MaxLength(36)]
    [MinLength(36)]
    public string UserId { get; set; }

    [Required]
    [MaxLength(36)]
    [MinLength(36)]
    public string TripId { get; set; }

    [ForeignKey(nameof(TripId))]
    public Trip Trip { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}
