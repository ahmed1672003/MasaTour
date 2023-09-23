namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class UserIdIsExistSpecification : Specification<User>
{
    public UserIdIsExistSpecification(string id) : base(user => user.Id.Equals(id))
    {
        StopTracking();
    }
}
