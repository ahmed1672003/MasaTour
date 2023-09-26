namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Users;
public sealed class AsNoTrackingGetDeletedUserByIdSpecification : Specification<User>
{
    public AsNoTrackingGetDeletedUserByIdSpecification(string userId) : base(user => user.Id.Equals(userId) && user.IsDeleted)
    {
        IgnorQueryFilter();
        StopTracking();
    }
}
