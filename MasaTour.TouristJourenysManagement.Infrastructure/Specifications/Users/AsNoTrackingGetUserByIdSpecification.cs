namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Users;
public sealed class AsNoTrackingGetUserByIdSpecification : Specification<User>
{
    public AsNoTrackingGetUserByIdSpecification(string id) : base(user => user.Id.Equals(id))
    {
        StopTracking();
    }
}
