namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingGetDeletedTransportationClassByNameARSpecification : Specification<TransportationClass>
{
    public AsNoTrackingGetDeletedTransportationClassByNameARSpecification(string nameAr)
        : base(t => t.IsDeleted && t.NameAR.Equals(nameAr))
    {
        StopTracking();
    }
}
