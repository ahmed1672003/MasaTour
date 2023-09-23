namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.JWTs;
public sealed class JwtIsExistSpecification : Specification<UserJWT>
{
    public JwtIsExistSpecification(string jwt, string refreshToken) : base(userJWT => userJWT.JWT.Equals(jwt) && userJWT.RefreshJWT.Equals(refreshToken) && userJWT.IsRefreshJWTUsed)
    {
        // StopTracking();
    }
}
