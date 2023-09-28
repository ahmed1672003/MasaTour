namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingGetMandatoryByNameARSpecification : Specification<Mandatory>
{
    public AsNoTrackingGetMandatoryByNameARSpecification(string nameAR) : base(m => m.NameAR.Equals(nameAR))
    {
        StopTracking();
    }
}
