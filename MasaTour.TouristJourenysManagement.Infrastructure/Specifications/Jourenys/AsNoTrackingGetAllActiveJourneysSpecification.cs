namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingGetAllActiveJourneysSpecification : Specification<Journey>
{
    public AsNoTrackingGetAllActiveJourneysSpecification() : base(j => j.IsActive)
    {
        StopTracking();
    }
}
