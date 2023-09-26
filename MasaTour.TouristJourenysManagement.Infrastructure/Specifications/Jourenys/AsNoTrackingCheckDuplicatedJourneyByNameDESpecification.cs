namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingCheckDuplicatedJourneyByNameDESpecification : Specification<Journey>
{
    public AsNoTrackingCheckDuplicatedJourneyByNameDESpecification(string journeyId, string nameDE)
        : base(journey => journey.NameDE.Equals(nameDE) && !journey.Id.Equals(journeyId))
    {
        StopTracking();
    }
}
