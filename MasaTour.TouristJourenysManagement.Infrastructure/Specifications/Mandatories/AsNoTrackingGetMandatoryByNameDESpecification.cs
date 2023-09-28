namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingGetMandatoryByNameDESpecification : Specification<Mandatory>
{
    public AsNoTrackingGetMandatoryByNameDESpecification(string nameDE) : base(m => m.NameDE.Equals(nameDE))
    {
        StopTracking();
    }
}
