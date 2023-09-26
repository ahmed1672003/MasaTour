namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Users;
public sealed class AsNoTrackingCheckIfPhoneNumberDuplicatedSpecification : Specification<User>
{
    public AsNoTrackingCheckIfPhoneNumberDuplicatedSpecification(string id, string phoneNumber)
             : base(user => (user.PhoneNumber.Equals(phoneNumber) && !user.Id.Equals(id)))
    {
        StopTracking();
    }
}
