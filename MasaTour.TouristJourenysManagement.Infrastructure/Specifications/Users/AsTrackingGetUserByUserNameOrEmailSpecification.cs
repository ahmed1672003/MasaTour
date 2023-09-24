namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class AsTrackingGetUserByUserNameOrEmailSpecification : Specification<User>
{
    public AsTrackingGetUserByUserNameOrEmailSpecification(string emailOrUserName) : base(user => user.Email.Equals(emailOrUserName) || user.UserName.Equals(emailOrUserName))
    {
    }
}
