using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public class UserTokenRepository : Repository<UserToken>, IUserTokenRepository
{
    public UserTokenRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
