namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetAllFamousTripsSpecification : Specification<Trip>
{
    public AsNoTrackingGetAllFamousTripsSpecification() : base(t => t.IsFamous)
    {
        StopTracking();
    }
}
