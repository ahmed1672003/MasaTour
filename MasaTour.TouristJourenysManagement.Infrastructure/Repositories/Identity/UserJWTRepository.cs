using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public class UserJWTRepository : Repository<UserJWT>, IUserJWTRepository
{
    public UserJWTRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
