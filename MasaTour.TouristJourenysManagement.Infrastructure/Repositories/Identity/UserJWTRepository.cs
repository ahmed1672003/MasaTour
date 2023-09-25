namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public sealed class UserJWTRepository : Repository<UserJWT>, IUserJWTRepository
{
    public UserJWTRepository(ITouristJourenysManagementDbContext context) : base(context) { }
}
