namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class CheckIfPhoneNumberDuplicatedSpecification : Specification<User>
{
    public CheckIfPhoneNumberDuplicatedSpecification(string id, string phoneNumber)
             : base(user => (user.PhoneNumber.Equals(phoneNumber) && !user.Id.Equals(id)))
    {
        StopTracking();
    }
}
