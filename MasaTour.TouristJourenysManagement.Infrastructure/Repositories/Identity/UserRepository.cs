using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
