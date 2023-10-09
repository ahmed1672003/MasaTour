namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetDeletedTransportationClassByIdSpecification : Specification<TransportationClass>
{
    public AsNoTrackingGetDeletedTransportationClassByIdSpecification(string id)
        : base(t => t.IsDeleted && t.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
