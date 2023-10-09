namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Transportations;
public sealed class AsTrackingGetTransportationByIdSpecification : Specification<Transportation>
{
    public AsTrackingGetTransportationByIdSpecification(string id)
        : base(t => t.Id.Equals(id))
    {

    }
}
