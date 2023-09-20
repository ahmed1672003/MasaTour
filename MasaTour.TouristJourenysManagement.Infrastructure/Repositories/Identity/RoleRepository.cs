using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(ITouristJourenysManagementDbContext context) : base(context)
    {
    }
}
