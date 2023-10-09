namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Transportations;
public sealed class AsNoTrackingGetDeletedTransportationByIdSpecification : Specification<Transportation>
{
    public AsNoTrackingGetDeletedTransportationByIdSpecification(string id) : base(t => t.IsDeleted && t.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
