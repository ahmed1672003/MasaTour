namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class AsTrackingGetDeletedUserByIdSpecification : Specification<User>
{
    public AsTrackingGetDeletedUserByIdSpecification(string userId) : base(user => user.Id.Equals(userId) && user.IsDeleted)
    {
        IgnorQueryFilter();
    }
}
