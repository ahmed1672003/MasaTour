﻿using MasaTour.TouristJourenysManagement.Domain.Abstracts;

namespace MasaTour.TouristJourenysManagement.Domain.Entities;

[PrimaryKey(nameof(CategoryId), nameof(JourneyId))]
public class CategoriesJourneysMapper : ICreateableTracker, IUpdateableTracker
{
    public string CategoryId { get; set; }
    public string JourneyId { get; set; }

    [AllowNull]
    public DateTime? UpdatedAt { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [NotMapped]
    [ForeignKey(nameof(CategoryId))]
    public Journey? Category { get; set; }

    [NotMapped]
    [ForeignKey(nameof(JourneyId))]
    public Journey? Journey { get; set; }
}
