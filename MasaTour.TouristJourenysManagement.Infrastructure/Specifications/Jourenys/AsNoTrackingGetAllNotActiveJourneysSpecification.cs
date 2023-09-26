namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingGetAllNotActiveJourneysSpecification : Specification<Journey>
{
    public AsNoTrackingGetAllNotActiveJourneysSpecification() : base(j => !j.IsActive)
    {
        StopTracking();
    }
}
