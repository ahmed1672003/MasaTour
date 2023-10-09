namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetTransportationClassByNameENSpecification : Specification<TransportationClass>
{
    public AsNoTrackingGetTransportationClassByNameENSpecification(string nameEn)
        : base(t => t.NameEN.Equals(nameEn))
    {
        StopTracking();
    }
}
