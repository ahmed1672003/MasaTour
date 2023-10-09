namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingCheckDuplicatedTransportationClassByNameENSpecification : Specification<TransportationClass>
{
    public AsNoTrackingCheckDuplicatedTransportationClassByNameENSpecification(string classId, string nameEn)
      : base(t => t.NameEN.Equals(nameEn) && !t.Id.Equals(classId))
    {
        StopTracking();
    }
}
