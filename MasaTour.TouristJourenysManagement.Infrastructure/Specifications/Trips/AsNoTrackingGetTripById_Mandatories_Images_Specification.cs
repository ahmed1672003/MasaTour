namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetTripById_Mandatories_Images_Specification : Specification<Trip>
{
    public AsNoTrackingGetTripById_Mandatories_Images_Specification(string tripId)
        : base(t => t.Id.Equals(tripId))
    {
        StopTracking();
        AddIncludesString($"{nameof(Trip.TripMandatoryMappers)}.{nameof(TripMandatoryMapper.Mandatory)}");
        AddIncludesString($"{nameof(Trip.TripImageMappers)}.{nameof(TripImageMapper.Image)}");
        //AddIncludes(t => t.TripImageMappers);
        //AddIncludes(t => t.TripMandatoryMappers);
    }
}
