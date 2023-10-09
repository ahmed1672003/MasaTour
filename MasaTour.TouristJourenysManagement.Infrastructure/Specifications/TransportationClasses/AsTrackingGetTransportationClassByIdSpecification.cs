namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsTrackingGetTransportationClassByIdSpecification : Specification<TransportationClass>
{
    public AsTrackingGetTransportationClassByIdSpecification(string id)
        : base(t => t.Id.Equals(id))
    {
    }
}
