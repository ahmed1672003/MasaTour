namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Users;
public class AsNoTrackingCheckIfUserNameDuplicatedSpecification : Specification<User>
{
    public AsNoTrackingCheckIfUserNameDuplicatedSpecification(string id, string userName)
        : base(user => (user.UserName.Equals(userName) && !user.Id.Equals(id)))
    {
        StopTracking();
    }
}
