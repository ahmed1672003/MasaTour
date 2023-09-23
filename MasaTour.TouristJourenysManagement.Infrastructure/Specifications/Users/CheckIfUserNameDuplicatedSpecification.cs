namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public class CheckIfUserNameDuplicatedSpecification : Specification<User>
{
    public CheckIfUserNameDuplicatedSpecification(string id, string userName)
        : base(user => (user.UserName.Equals(userName) && !user.Id.Equals(id)))
    {
        StopTracking();
    }
}
