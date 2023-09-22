namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class PhoneNumberIsExistSpecification : Specification<User>
{
    public PhoneNumberIsExistSpecification(string phoneNumber) : base(user => user.PhoneNumber.Equals(phoneNumber))
    {

    }
}
