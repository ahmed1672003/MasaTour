namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingCheckDuplicatedMandatoryByNameARSpecification : Specification<Mandatory>
{
    public AsNoTrackingCheckDuplicatedMandatoryByNameARSpecification(string id, string nameAR)
        : base(m => m.NameAR.Equals(nameAR) && !m.Id.Equals(id))
    {
        StopTracking();
    }
}
