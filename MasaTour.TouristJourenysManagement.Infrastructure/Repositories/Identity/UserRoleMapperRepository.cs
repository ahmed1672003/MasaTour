using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public class UserRoleMapperRepository : Repository<UserRoleMapper>, IUserRoleMapperRepository
{
    public UserRoleMapperRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
