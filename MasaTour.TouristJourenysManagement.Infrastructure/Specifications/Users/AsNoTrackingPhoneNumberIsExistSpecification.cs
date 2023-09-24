namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
public sealed class AsNoTrackingPhoneNumberIsExistSpecification : Specification<User>
{
    public AsNoTrackingPhoneNumberIsExistSpecification(string phoneNumber) : base(user => user.PhoneNumber.Equals(phoneNumber))
    {
        StopTracking();
    }
}
