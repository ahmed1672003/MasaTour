namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameENSpecification : Specification<TransportationClass>
{
    public AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameENSpecification(string id, string nameEn)
        : base(t => t.IsDeleted && t.NameEN.Equals(nameEn) && !t.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
