namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public class UserNameIsExistSpecification : Specification<User>
{
    public UserNameIsExistSpecification(string userName) : base(user => user.UserName.Equals(userName)) { }
}
