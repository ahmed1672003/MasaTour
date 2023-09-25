namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public sealed class UserTokenRepository : Repository<UserToken>, IUserTokenRepository
{
    public UserTokenRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
