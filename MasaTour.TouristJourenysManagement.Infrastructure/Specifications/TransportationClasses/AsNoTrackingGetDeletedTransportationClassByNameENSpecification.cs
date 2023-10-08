namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetDeletedTransportationClassByNameENSpecification : Specification<TransporationClass>
{
    public AsNoTrackingGetDeletedTransportationClassByNameENSpecification(string nameEn)
        : base(t => t.IsDeleted && t.NameEN.Equals(nameEn))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
