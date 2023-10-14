namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Users;
public sealed class AsTrackingGetUserByIdSpecification : Specification<User>
{
    public AsTrackingGetUserByIdSpecification(string id) : base(user => user.Id.Equals(id))
    {


    }
}
