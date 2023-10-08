namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetTransportationByIdSpecification : Specification<TransporationClass>
{
    public AsNoTrackingGetTransportationByIdSpecification(string id)
        : base(t => t.Id.Equals(id))
    {
        StopTracking();
    }
}
