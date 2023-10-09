namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Transportations;
public sealed class AsNoTrackingGetAllDeletedTransportationsSpecification : Specification<Transportation>
{
    public AsNoTrackingGetAllDeletedTransportationsSpecification() : base(t => t.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
