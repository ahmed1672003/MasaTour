namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingGetAllMandatoriesSpecification : Specification<Mandatory>
{
    public AsNoTrackingGetAllMandatoriesSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
