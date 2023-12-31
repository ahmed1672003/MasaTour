﻿namespace MasaTour.TouristTripsManagement.Domain.Entities;

[PrimaryKey(nameof(MandatoryId), nameof(TripId))]
public class TripMandatoryMapper
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
}
