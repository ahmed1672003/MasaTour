namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingGetJourneyByNameARSpecification : Specification<Journey>
{
    public AsNoTrackingGetJourneyByNameARSpecification(string nameAr) : base(j => j.NameAR.Equals(nameAr))
    {
        StopTracking();
    }
}
