namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetTransportationClassByIdSpecification : Specification<TransportationClass>
{
    public AsNoTrackingGetTransportationClassByIdSpecification(string id)
        : base(t => t.Id.Equals(id))
    {
        StopTracking();
    }
}
