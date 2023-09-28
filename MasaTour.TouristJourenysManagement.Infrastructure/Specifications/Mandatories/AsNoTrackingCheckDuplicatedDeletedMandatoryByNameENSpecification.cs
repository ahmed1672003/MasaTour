namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingCheckDuplicatedDeletedMandatoryByNameENSpecification : Specification<Mandatory>
{
    public AsNoTrackingCheckDuplicatedDeletedMandatoryByNameENSpecification(string id, string nameEN)
        : base(m => m.IsDeleted && m.NameEN.Equals(nameEN) && !m.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
