namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetAllDeletedTranspotationClassesSpecification : Specification<TransportationClass>
{
    public AsNoTrackingGetAllDeletedTranspotationClassesSpecification() : base(t => t.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
