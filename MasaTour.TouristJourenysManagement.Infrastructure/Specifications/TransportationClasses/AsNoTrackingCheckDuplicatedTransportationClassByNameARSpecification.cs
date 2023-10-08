
namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TransportationClasses;
public sealed class AsNoTrackingCheckDuplicatedTransportationClassByNameARSpecification : Specification<TransporationClass>
{
    public AsNoTrackingCheckDuplicatedTransportationClassByNameARSpecification(string classId, string nameAr)
        : base(t => t.NameAR.Equals(nameAr) && !t.Id.Equals(classId))
    {
        StopTracking();
    }
}
