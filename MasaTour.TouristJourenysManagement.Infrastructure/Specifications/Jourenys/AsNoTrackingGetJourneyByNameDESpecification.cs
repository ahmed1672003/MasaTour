namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingGetJourneyByNameDESpecification : Specification<Journey>
{
    public AsNoTrackingGetJourneyByNameDESpecification(string nameDE) : base(j => j.NameDE.Equals(nameDE))
    {
        StopTracking();
    }
}
