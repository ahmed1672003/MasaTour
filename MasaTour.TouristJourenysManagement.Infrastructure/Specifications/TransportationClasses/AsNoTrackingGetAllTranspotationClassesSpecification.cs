namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetAllTranspotationClassesSpecification : Specification<TransportationClass>
{
    public AsNoTrackingGetAllTranspotationClassesSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
