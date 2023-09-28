namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingGetMandatoryByNameENSpecification : Specification<Mandatory>
{
    public AsNoTrackingGetMandatoryByNameENSpecification(string nameEN) : base(m => m.NameEN.Equals(nameEN))
    {
        StopTracking();
    }
}
