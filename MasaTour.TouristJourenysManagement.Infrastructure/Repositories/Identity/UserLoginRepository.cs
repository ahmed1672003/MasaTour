using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public class UserLoginRepository : Repository<UserLogin>, IUserLoginRepository
{
    public UserLoginRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
