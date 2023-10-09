namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsTrackingGetDeletedTransportationClassByIdSpecification : Specification<TransportationClass>
{
    public AsTrackingGetDeletedTransportationClassByIdSpecification(string id) : base(t => t.IsDeleted && t.Id.Equals(id))
    {
        IgnorQueryFilter();
    }
}
