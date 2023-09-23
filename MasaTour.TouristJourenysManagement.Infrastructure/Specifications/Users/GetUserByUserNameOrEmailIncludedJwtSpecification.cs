namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class GetUserByUserNameOrEmailIncludedJwtSpecification : Specification<User>
{
    public GetUserByUserNameOrEmailIncludedJwtSpecification(string emailOrUserName) : base(user => user.Email.Equals(emailOrUserName) || user.UserName.Equals(emailOrUserName))
    {
        AddIncludes(user => user.UserJWTs);
    }
}
