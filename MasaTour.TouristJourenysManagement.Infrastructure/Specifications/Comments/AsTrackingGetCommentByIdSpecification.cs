namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Comments;
public sealed class AsTrackingGetCommentByIdSpecification : Specification<Comment>
{
    public AsTrackingGetCommentByIdSpecification(string commentId) : base(c => c.Id.Equals(commentId))
    {

    }
}
