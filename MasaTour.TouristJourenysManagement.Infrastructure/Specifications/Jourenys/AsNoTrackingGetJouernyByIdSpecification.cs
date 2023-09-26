namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsNoTrackingGetJouernyByIdSpecification : Specification<Journey>
{
    public AsNoTrackingGetJouernyByIdSpecification(string id) : base(journey => journey.Id.Equals(id))
    {
        StopTracking();
    }
}
