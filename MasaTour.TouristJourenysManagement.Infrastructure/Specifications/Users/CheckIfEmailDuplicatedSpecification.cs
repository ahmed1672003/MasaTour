namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class CheckIfEmailDuplicatedSpecification : Specification<User>
{
    public CheckIfEmailDuplicatedSpecification(string id, string email)
             : base(user => (user.Email.Equals(email) && !user.Id.Equals(id)))
    {
        StopTracking();
    }
}
