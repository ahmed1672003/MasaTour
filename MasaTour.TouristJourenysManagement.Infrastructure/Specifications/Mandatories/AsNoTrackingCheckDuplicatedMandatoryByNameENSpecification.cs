namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingCheckDuplicatedMandatoryByNameENSpecification : Specification<Mandatory>
{
    public AsNoTrackingCheckDuplicatedMandatoryByNameENSpecification(string id, string nameEN)
        : base(m => m.NameEN.Equals(nameEN) && !m.Id.Equals(id))
    {
        StopTracking();
    }
}
