namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class AsTrackingGetUserByUserNameOrEmailIncludedJwtSpecification : Specification<User>
{
    public AsTrackingGetUserByUserNameOrEmailIncludedJwtSpecification(string emailOrUserName) : base(user => user.Email.Equals(emailOrUserName) || user.UserName.Equals(emailOrUserName))
    {
        AddIncludes(user => user.UserJWTs);
    }
}
