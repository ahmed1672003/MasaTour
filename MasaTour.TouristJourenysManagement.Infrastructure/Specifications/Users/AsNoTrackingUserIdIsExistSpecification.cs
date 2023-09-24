namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class AsNoTrackingUserIdIsExistSpecification : Specification<User>
{
    public AsNoTrackingUserIdIsExistSpecification(string id) : base(user => user.Id.Equals(id))
    {
        StopTracking();
    }
}
