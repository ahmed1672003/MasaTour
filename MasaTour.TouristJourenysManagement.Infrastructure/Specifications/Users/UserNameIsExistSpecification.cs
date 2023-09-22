namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class UserNameIsExistSpecification : Specification<User>
{
    public UserNameIsExistSpecification(string userName) : base(user => user.UserName.Equals(userName)) { }
}
