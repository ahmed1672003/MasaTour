namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetAllTranspotationClassesSpecification : Specification<TransporationClass>
{
    public AsNoTrackingGetAllTranspotationClassesSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
