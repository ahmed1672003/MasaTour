namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsTrackingGetTransportationClassByIdSpecification : Specification<TransporationClass>
{
    public AsTrackingGetTransportationClassByIdSpecification(string id)
        : base(t => t.Id.Equals(id))
    {
        StopTracking();
    }
}
