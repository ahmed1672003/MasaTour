namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameARSpecification : Specification<TransporationClass>
{
    public AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameARSpecification(string id, string nameAr)
        : base(t => t.IsDeleted && t.NameAR.Equals(nameAr) && !t.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
