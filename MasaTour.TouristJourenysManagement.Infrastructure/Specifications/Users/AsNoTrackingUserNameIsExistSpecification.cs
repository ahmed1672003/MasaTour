namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class AsNoTrackingUserNameIsExistSpecification : Specification<User>
{
    public AsNoTrackingUserNameIsExistSpecification(string userName) : base(user => user.UserName.Equals(userName))
    {
        StopTracking();
    }
}
