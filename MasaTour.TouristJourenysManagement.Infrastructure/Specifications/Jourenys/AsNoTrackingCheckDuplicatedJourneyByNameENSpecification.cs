namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingCheckDuplicatedJourneyByNameENSpecification : Specification<Journey>
{
    public AsNoTrackingCheckDuplicatedJourneyByNameENSpecification(string jourenyId, string nameEN)
        : base(joureny => joureny.NameEN.Equals(nameEN) && !joureny.Id.Equals(jourenyId))
    {
        StopTracking();
    }
}
