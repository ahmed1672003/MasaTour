namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.JWTs;
public sealed class AsTrackingGetUserJWTByJwtAndRefreshJwtIncludedSpecification : Specification<UserJWT>
{
    public AsTrackingGetUserJWTByJwtAndRefreshJwtIncludedSpecification(string jwt, string refreshToken) : base(userJwt => userJwt.JWT.Equals(jwt) && userJwt.RefreshJWT.Equals(refreshToken) && userJwt.IsRefreshJWTUsed)
    {
        AddIncludes(userJwt => userJwt.User);
    }
}
