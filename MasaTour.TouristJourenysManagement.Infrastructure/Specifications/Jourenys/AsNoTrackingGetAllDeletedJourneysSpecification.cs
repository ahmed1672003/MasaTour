namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingGetAllDeletedJourneysSpecification : Specification<Journey>
{
    public AsNoTrackingGetAllDeletedJourneysSpecification() : base(j => j.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
