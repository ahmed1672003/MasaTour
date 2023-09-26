namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetTripByNameARSpecification : Specification<Trip>
{
    public AsNoTrackingGetTripByNameARSpecification(string nameAr) : base(j => j.NameAR.Equals(nameAr))
    {
        StopTracking();
    }
}
