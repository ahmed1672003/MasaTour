namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingCheckDuplicatedTransportationClassByNameDESpecification : Specification<TransportationClass>
{
    public AsNoTrackingCheckDuplicatedTransportationClassByNameDESpecification(string classId, string nameDe)
       : base(t => t.NameDE.Equals(nameDe) && !t.Id.Equals(classId))
    {
        StopTracking();
    }
}
