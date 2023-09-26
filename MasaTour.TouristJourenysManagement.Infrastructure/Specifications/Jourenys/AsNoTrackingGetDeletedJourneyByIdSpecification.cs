﻿namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingGetDeletedJourneyByIdSpecification : Specification<Journey>
{
    public AsNoTrackingGetDeletedJourneyByIdSpecification(string id) : base(journey => journey.Id.Equals(id) && journey.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
