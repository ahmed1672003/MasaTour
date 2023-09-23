namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.JWTs;
public sealed class GetUserJWTByJwtAndRefreshJwtIncludedSpecification : Specification<UserJWT>
{
    public GetUserJWTByJwtAndRefreshJwtIncludedSpecification(string jwt, string refreshToken) : base(userJwt => userJwt.JWT.Equals(jwt) && userJwt.RefreshJWT.Equals(refreshToken) && userJwt.IsRefreshJWTUsed)
    {
        AddIncludes(userJwt => userJwt.User);
    }
}
