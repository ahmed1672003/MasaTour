namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetAllUnFamousTripsSpecification : Specification<Trip>
{
    public AsNoTrackingGetAllUnFamousTripsSpecification() : base(t => !t.IsFamous)
    {
        StopTracking();
    }
}
