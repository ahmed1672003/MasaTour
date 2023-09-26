using MasaTour.TouristTripsManagement.Domain.Abstracts;

namespace MasaTour.TouristTripsManagement.Domain.Entities;

[PrimaryKey(nameof(CategoryId), nameof(TripId))]
public class CategoriesTripsMapper : ICreateableTracker, IUpdateableTracker
{
    public string CategoryId { get; set; }
    public string TripId { get; set; }

    [AllowNull]
    public DateTime? UpdatedAt { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }

    [ForeignKey(nameof(TripId))]
    public Trip Trip { get; set; }
}
