namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingCheckDuplicatedDeletedMandatoryByNameARSpecification : Specification<Mandatory>
{
    public AsNoTrackingCheckDuplicatedDeletedMandatoryByNameARSpecification(string id, string nameAR)
        : base(m => m.IsDeleted && m.NameAR.Equals(nameAR) && !m.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
