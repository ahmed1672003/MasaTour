namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.TripImagesMappers;
public sealed class AsNoTrackingGetTripImagesMappersByCompositeKeySpecification : Specification<TripImageMapper>
{
    public AsNoTrackingGetTripImagesMappersByCompositeKeySpecification(string tripId, List<string> imagesIds)
        : base(tim => tim.TripId.Equals(tripId) && imagesIds.Contains(tim.ImageId))
    {
        StopTracking();
    }
}
