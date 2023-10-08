namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetDeletedTransportationClassByNameDESpecification : Specification<TransporationClass>
{
    public AsNoTrackingGetDeletedTransportationClassByNameDESpecification(string nameDe)
        : base(t => t.IsDeleted && t.NameDE.Equals(nameDe))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
