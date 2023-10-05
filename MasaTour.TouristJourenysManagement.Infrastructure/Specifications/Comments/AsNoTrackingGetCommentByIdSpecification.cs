namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Comments;
internal class AsNoTrackingGetCommentByIdSpecification : Specification<Comment>
{
    public AsNoTrackingGetCommentByIdSpecification(string commentId) : base(c => c.Id.Equals(commentId))
    {
        StopTracking();
    }
}
