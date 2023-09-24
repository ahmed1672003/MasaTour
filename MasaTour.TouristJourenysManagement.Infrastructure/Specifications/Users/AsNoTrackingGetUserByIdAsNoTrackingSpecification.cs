namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class AsNoTrackingGetUserByIdAsNoTrackingSpecification : Specification<User>
{
    public AsNoTrackingGetUserByIdAsNoTrackingSpecification(string id) : base(user => user.Id.Equals(id))
    {
        StopTracking();
    }
}
