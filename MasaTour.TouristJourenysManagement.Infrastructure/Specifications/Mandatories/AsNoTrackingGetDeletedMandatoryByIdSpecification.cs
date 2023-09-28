namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingGetDeletedMandatoryByIdSpecification : Specification<Mandatory>
{
    public AsNoTrackingGetDeletedMandatoryByIdSpecification(string id) : base(m => m.IsDeleted && m.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
