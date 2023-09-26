namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingCheckDuplicatedJourneyByNameARSpecification : Specification<Journey>
{
    public AsNoTrackingCheckDuplicatedJourneyByNameARSpecification(string journeyId, string nameAR)
        : base(journey => journey.NameAR.Equals(nameAR) && !journey.Id.Equals(journeyId))
    {
        StopTracking();
    }
}
