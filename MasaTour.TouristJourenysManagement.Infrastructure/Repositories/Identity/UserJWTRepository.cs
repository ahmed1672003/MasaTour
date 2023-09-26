namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Identity;
public sealed class UserJWTRepository : Repository<UserJWT>, IUserJWTRepository
{
    public UserJWTRepository(ITouristTripsManagementDbContext context) : base(context) { }
}
