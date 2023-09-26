namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsTrackingGetTripByIdSpecification : Specification<Trip>
{
    public AsTrackingGetTripByIdSpecification(string id) : base(Trip => Trip.Id.Equals(id))
    {

    }
}
