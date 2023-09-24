namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.JWTs;
public sealed class AsNoTrackingJwtIsExistSpecification : Specification<UserJWT>
{
    public AsNoTrackingJwtIsExistSpecification(string jwt, string refreshToken) : base(userJWT => userJWT.JWT.Equals(jwt) && userJWT.RefreshJWT.Equals(refreshToken) && userJWT.IsRefreshJWTUsed)
    {
        StopTracking();
    }
}
