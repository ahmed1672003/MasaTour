namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Users;
public sealed class AsNoTrackingEmailIsExistSpecification : Specification<User>
{
    public AsNoTrackingEmailIsExistSpecification(string email) : base(user => user.Email.Equals(email))
    {
        StopTracking();
    }
}
