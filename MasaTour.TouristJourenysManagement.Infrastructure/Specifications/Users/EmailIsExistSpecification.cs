namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class EmailIsExistSpecification : Specification<User>
{
    public EmailIsExistSpecification(string email) : base(user => user.Email.Equals(email)) { }
}
