namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;

public sealed class AsNoTrackingCheckDuplicatedMandatoryByNameDESpecification : Specification<Mandatory>
{
    public AsNoTrackingCheckDuplicatedMandatoryByNameDESpecification(string id, string nameDE)
        : base(m => m.NameDE.Equals(nameDE) && !m.Id.Equals(id))
    {
        StopTracking();
    }
}
