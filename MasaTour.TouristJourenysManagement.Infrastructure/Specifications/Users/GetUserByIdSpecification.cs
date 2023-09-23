namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class GetUserByIdSpecification : Specification<User>
{
    public GetUserByIdSpecification(string id) : base(user => user.Id.Equals(id))
    {

    }
}
