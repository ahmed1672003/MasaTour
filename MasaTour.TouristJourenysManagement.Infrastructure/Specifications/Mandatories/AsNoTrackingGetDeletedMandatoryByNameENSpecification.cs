namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingGetDeletedMandatoryByNameENSpecification : Specification<Mandatory>
{
    public AsNoTrackingGetDeletedMandatoryByNameENSpecification(string nameEN) : base(m => m.IsDeleted && m.NameEN.Equals(nameEN))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
