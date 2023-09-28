namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingGetDeletedMandatoryByNameARSpecification : Specification<Mandatory>
{
    public AsNoTrackingGetDeletedMandatoryByNameARSpecification(string nameAR) : base(m => m.IsDeleted && m.NameAR.Equals(nameAR))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
