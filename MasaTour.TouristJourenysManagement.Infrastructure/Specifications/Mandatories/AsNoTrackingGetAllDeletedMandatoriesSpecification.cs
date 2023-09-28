namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingGetAllDeletedMandatoriesSpecification : Specification<Mandatory>
{
    public AsNoTrackingGetAllDeletedMandatoriesSpecification() : base(m => m.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
