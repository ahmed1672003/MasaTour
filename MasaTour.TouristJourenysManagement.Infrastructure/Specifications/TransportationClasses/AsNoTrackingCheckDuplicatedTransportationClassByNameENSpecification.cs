namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingCheckDuplicatedTransportationClassByNameENSpecification : Specification<TransporationClass>
{
    public AsNoTrackingCheckDuplicatedTransportationClassByNameENSpecification(string classId, string nameEn)
      : base(t => t.NameEN.Equals(nameEn) && !t.Id.Equals(classId))
    {
        StopTracking();
    }
}
