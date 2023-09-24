namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class AsNoTrackingChangeVisibilitySpecification : Specification<User>
{
    public AsNoTrackingChangeVisibilitySpecification(string userId, bool isDeleted) :
        base(user => user.Id.Equals(userId))
    {
        IgnorQueryFilter();
    }
}
