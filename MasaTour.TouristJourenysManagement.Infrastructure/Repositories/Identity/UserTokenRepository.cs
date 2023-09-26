namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Identity;
public sealed class UserTokenRepository : Repository<UserToken>, IUserTokenRepository
{
    public UserTokenRepository(ITouristTripsManagementDbContext context) : base(context)
    {
    }
}
