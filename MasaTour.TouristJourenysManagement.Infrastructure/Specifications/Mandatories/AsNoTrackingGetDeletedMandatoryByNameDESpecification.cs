namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingGetDeletedMandatoryByNameDESpecification : Specification<Mandatory>
{
    public AsNoTrackingGetDeletedMandatoryByNameDESpecification(string nameDE) : base(m => m.IsDeleted && m.NameDE.Equals(nameDE))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
