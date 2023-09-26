namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Identity;
public sealed class UserLoginRepository : Repository<UserLogin>, IUserLoginRepository
{
    public UserLoginRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
