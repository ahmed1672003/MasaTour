namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Comments;
public sealed class AsTrackingGetDeletedCommentByIdSpecification : Specification<Comment>
{
    public AsTrackingGetDeletedCommentByIdSpecification(string commentId) : base(c => c.Id.Equals(commentId) && c.IsDeleted)
    {
        IgnorQueryFilter();
    }
}
