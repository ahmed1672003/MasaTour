namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Comments;
public sealed class AsNoTrackingGetAllCommentsByTripIdSpecification : Specification<Comment>
{
    public AsNoTrackingGetAllCommentsByTripIdSpecification(string tripId)
        : base(c => c.TripId.Equals(tripId))
    {
        StopTracking();
    }
}
