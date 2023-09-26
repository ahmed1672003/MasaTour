namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Jourenys;
public sealed class AsTrackingGetJouernyByIdSpecification : Specification<Journey>
{
    public AsTrackingGetJouernyByIdSpecification(string id) : base(journey => journey.Id.Equals(id))
    {

    }
}
