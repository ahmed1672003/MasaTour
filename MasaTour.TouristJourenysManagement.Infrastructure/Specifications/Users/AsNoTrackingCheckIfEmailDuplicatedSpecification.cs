namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Users;
public sealed class AsNoTrackingCheckIfEmailDuplicatedSpecification : Specification<User>
{
    public AsNoTrackingCheckIfEmailDuplicatedSpecification(string id, string email)
             : base(user => (user.Email.Equals(email) && !user.Id.Equals(id)))
    {
        StopTracking();
    }
}
