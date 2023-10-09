namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetTransportationClassByNameARSpecification : Specification<TransportationClass>
{
    public AsNoTrackingGetTransportationClassByNameARSpecification(string nameAr)
        : base(t => t.NameAR.Equals(nameAr))
    {
        StopTracking();
    }
}
