namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameDESpecification : Specification<TransporationClass>
{
    public AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameDESpecification(string id, string nameDe)
        : base(t => t.IsDeleted && t.NameDE.Equals(nameDe) && !t.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
