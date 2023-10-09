namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetTransportationClassByNameDESpecification : Specification<TransportationClass>
{
    public AsNoTrackingGetTransportationClassByNameDESpecification(string nameDe)
        : base(t => t.NameDE.Equals(nameDe))
    {
        StopTracking();
    }
}
