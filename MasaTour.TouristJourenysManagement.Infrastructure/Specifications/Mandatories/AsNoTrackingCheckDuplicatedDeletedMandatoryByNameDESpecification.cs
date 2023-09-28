namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingCheckDuplicatedDeletedMandatoryByNameDESpecification : Specification<Mandatory>
{
    public AsNoTrackingCheckDuplicatedDeletedMandatoryByNameDESpecification(string id, string nameDE)
        : base(m => m.IsDeleted && m.NameDE.Equals(nameDE) && !m.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
