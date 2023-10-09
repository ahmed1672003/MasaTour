namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Transportations;
public sealed class AsNoTrackingGetTransportationByIdSpecification : Specification<Transportation>
{
    public AsNoTrackingGetTransportationByIdSpecification(string id) : base(t => t.Id.Equals(id))
    {
        StopTracking();
    }
}
