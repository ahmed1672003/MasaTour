namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingGetAllJourneysSpecification : Specification<Journey>
{
    public AsNoTrackingGetAllJourneysSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
