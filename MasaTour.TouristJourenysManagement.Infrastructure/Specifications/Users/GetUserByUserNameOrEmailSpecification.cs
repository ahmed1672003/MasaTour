namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class GetUserByUserNameOrEmailSpecification : Specification<User>
{
    public GetUserByUserNameOrEmailSpecification(string emailOrUserName) : base(user => user.Email.Equals(emailOrUserName) || user.UserName.Equals(emailOrUserName))
    {
    }
}
