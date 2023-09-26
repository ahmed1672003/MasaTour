namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingGetJourneyByNameENSpecification : Specification<Journey>
{
    public AsNoTrackingGetJourneyByNameENSpecification(string nameEN) : base(j => j.NameEN.Equals(nameEN))
    {
        StopTracking();
    }
}
